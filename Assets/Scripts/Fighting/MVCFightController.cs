using Profile;
using UnityEngine;

namespace Fighting
{
    public class MVCFightController : BaseController
    {
        private readonly ResourcePath _fightResource;
        private readonly ProfilePlayer _profilePlayer;
        private MVCFightWindow _fightWindow;

        private Enemy _enemy;
        private Health _playerHealth;
        private Money _playerMoney;
        private Power _playerPower;
        private Pursuit _playerPursuit;

        public MVCFightController(ResourcePath fightResource, ProfilePlayer profilePlayer, Transform placeForUI)
        {
            _fightResource = fightResource;
            _profilePlayer = profilePlayer;
            _playerHealth = new Health();
            _playerMoney = new Money();
            _playerPower = new Power();
            _playerPursuit = new Pursuit();
            

            var obj = ResourceLoader.LoadObject<MVCFightWindow>(fightResource);
            _fightWindow = Object.Instantiate(obj/*, placeForUI*/);
            _fightWindow.OnGoBackButtonPressed += GoBack;
            AddGameObjects(_fightWindow.gameObject);
            
            _profilePlayer.Health.SubscribeOnChange(v => _fightWindow.Health = v);
            _profilePlayer.Money.SubscribeOnChange(v => _fightWindow.Money = v);
            _profilePlayer.Power.SubscribeOnChange(v => _fightWindow.Power = v);
            _profilePlayer.Pursuit.SubscribeOnChange(v => _fightWindow.Pursuit = v);
            
            _fightWindow.Init(ChangeMoney, ChangeHealth, ChangePower, ChangePursuit, Fight, Skip);
            _fightWindow.DisableSkipButton(false);

            _enemy = new Enemy("Bird", 0.2f);
            _enemy.OnUpdate += OnEnemyUpdate;
            UpdateInfoForEnemy();
            SubscribeEnemy(_enemy);
            
        }

        private void IsBattleSkipPossible()
        {
            if (_profilePlayer.Pursuit.Value < 5 || _profilePlayer.Power.Value > _enemy.Power + (_enemy.Power * _enemy._kEnemyEscape))
            {
                _fightWindow.DisableSkipButton(false);
            }
            else
            {
                _fightWindow.DisableSkipButton(true);
            }
        }

        private void UpdateInfoForEnemy()
        {
            _playerHealth.Health = (int)_profilePlayer.Health.Value;
            _playerMoney.Money = _profilePlayer.Money.Value;
            _playerPower.Power = (int)_profilePlayer.Power.Value;
            _playerPursuit.PursuitCounter = _profilePlayer.Pursuit.Value;
            IsBattleSkipPossible();
        }

        private void SubscribeEnemy(Enemy enemy)
        {
            _playerHealth.Subscribe(enemy);
            _playerMoney.Subscribe(enemy);
            _playerPower.Subscribe(enemy);
            _playerPursuit.Subscribe(enemy);
        }

        private void OnEnemyUpdate(Enemy obj)
        {
            _fightWindow.EnemyPower = $"Enemy Power: {obj.Power}";
        }

        private void Skip()
        {
            Debug.Log($"Fight complete. Enemy Escaped");
            GoBack();
        }

        private void Fight()
        {
            var result = _profilePlayer.Power.Value < _enemy.Power ? "You Loooose..." : "You WIN!!!";
            Debug.Log($"Fight complete. Result = {result}");
        }

        private void ChangePursuit(bool value)
        {
            _profilePlayer.Pursuit.Value += value ? 1 : -1;
            UpdateInfoForEnemy();
        }

        private void ChangePower(bool value)
        {
            _profilePlayer.Power.Value += value ? 1 : -1;
            UpdateInfoForEnemy();
        }

        private void ChangeHealth(bool value)
        {
            _profilePlayer.Health.Value += value ? 1 : -1;
            UpdateInfoForEnemy();
        }

        private void ChangeMoney(bool value)
        {
            _profilePlayer.Money.Value += value ? 1 : -1;
            UpdateInfoForEnemy();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            if (_fightWindow != null)
                _fightWindow.OnGoBackButtonPressed -= GoBack;
        }

        private void GoBack()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }
    }
}