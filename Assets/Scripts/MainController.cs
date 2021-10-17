using System.Collections.Generic;
using Profile;
using UnityEngine;
using Utilities.Ads;

public class MainController : BaseController
{
     private MainMenuController _mainMenuController;
     private GameController _gameController;
     private readonly Transform _placeForUi;
     private readonly ProfilePlayer _profilePlayer;
     private readonly IAdsShower _adsShower;
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower)
    {
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }
 
    

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _adsShower);
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _profilePlayer.Analytics.SendMessage("GameStarted", new Dictionary<string, object>());
                
                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                break;
            case GameState.Shop:
                //TODO ShopController
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }
}
