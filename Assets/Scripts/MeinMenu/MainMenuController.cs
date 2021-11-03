using Profile;
using UnityEngine;
using Utilities.Ads;

public class MainMenuController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
    private readonly ProfilePlayer _profilePlayer;
    private readonly IAdsShower _adsShower;
    private readonly MainMenuView _view;

    public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower)
    {
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        _view = LoadView(placeForUi);
        _view.Init(StartGame, ShowAddRequested, ShowGarage,GetDaily,ExitGame);
    }
    
    private MainMenuView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        
        return objectView.GetComponent<MainMenuView>();
    }

    private void ShowAddRequested()
    {
        _adsShower.ShowVideo(OnVideoShowSuccess);
    }

    private void OnVideoShowSuccess()
    {
        _profilePlayer.AddReward(10);
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    private void ShowGarage()
    {
        _profilePlayer.CurrentState.Value = GameState.Garage;
    }

    private void ExitGame()
    {
        
    }

    private void GetDaily()
    {
        
    }
}

