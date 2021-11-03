using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Fighting
{
    public class MVCFightWindow : MonoBehaviour
    {
        [SerializeField] private Text _moneyCountText;
        [SerializeField] private Text _healthCountText;
        [SerializeField] private Text _powerCountText;
    
        [SerializeField] private Text _enemyPowerCountText;

        [SerializeField] private Button _addMoney;
        [SerializeField] private Button _minusMoney;
        [SerializeField] private Button _addPower;
        [SerializeField] private Button _minusPower;
        [SerializeField] private Button _addHealth;
        [SerializeField] private Button _minusHealth;
    
        [SerializeField] private Button _startFight;
    
        [SerializeField] private Text _pursuitCounter;
        [SerializeField] private Button _addPursuit;
        [SerializeField] private Button _minusPursuit;
    
        [SerializeField] private Button _skipBattle;

        [SerializeField] public Button _goBackButton;

        public Action OnGoBackButtonPressed;

        private Enemy _enemy;
        
        public float Health
        {
            set => _healthCountText.text = value.ToString();
        }
        public int Money
        {
            set => _moneyCountText.text = value.ToString();
        }
        public float Power
        {
            set => _powerCountText.text = value.ToString();
        }
        public int Pursuit
        {
            set => _pursuitCounter.text = value.ToString();
        }
        public string EnemyPower
        {
            set => _enemyPowerCountText.text = value;
        }

        public void Init(UnityAction<bool> changeMoney, UnityAction<bool> changeHealth, UnityAction<bool> changePower,
            UnityAction<bool> changePursuit, UnityAction fight, UnityAction skip)
        {
            _addMoney.onClick.AddListener(() => changeMoney(true));
            _minusMoney.onClick.AddListener(() => changeMoney(false));

            _addHealth.onClick.AddListener(() => changeHealth(true));
            _minusHealth.onClick.AddListener(() => changeHealth(false));

            _addPower.onClick.AddListener(() => changePower(true));
            _minusPower.onClick.AddListener(() => changePower(false));
        
            _addPursuit.onClick.AddListener(() => changePursuit(true));
            _minusPursuit.onClick.AddListener(() => changePursuit(false));

            _startFight.onClick.AddListener(fight);
            _skipBattle.onClick.AddListener(skip);
            
            _goBackButton.onClick.AddListener(()=>OnGoBackButtonPressed?.Invoke());
            
            
           
        }
        
        public void DisableSkipButton(bool state)
        {
            _skipBattle.enabled = !state;
            _skipBattle.image.color = state ? Color.gray : Color.green;
        }
    }
}