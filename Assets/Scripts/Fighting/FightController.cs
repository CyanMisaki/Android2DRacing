using Profile;
using UnityEngine;

namespace Fighting
{
    /*public class FightController : BaseController
    {
        private readonly ResourcePath _fightResource;
        private readonly ProfilePlayer _profilePlayer;
        private FightWindow _fightWindow;


        public FightController(ResourcePath fightResource, ProfilePlayer profilePlayer, Transform placeForUI)
        {
            _fightResource = fightResource;
            _profilePlayer = profilePlayer;

            var obj = ResourceLoader.LoadObject<FightWindow>(fightResource);
            _fightWindow = Object.Instantiate(obj/*, placeForUI#1#);
            _fightWindow.OnGoBackButtonPressed += GoBack;
            AddGameObjects(_fightWindow.gameObject);
            
            
            
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
    }*/
}