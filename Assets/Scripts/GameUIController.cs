using Profile;
using UnityEngine;

public class GameUIController : BaseController
{
    private readonly Transform _placeForUI;
    private readonly ProfilePlayer _profilePlayer;
    private ResourcePath path = new ResourcePath() { PathResource = "Prefabs/GameUIView" };

    private GameUIView _gameUIView;
    public GameUIController(Transform placeForUI, ProfilePlayer profilePlayer)
    {
        _placeForUI = placeForUI;
        _profilePlayer = profilePlayer;
        
        var obj = ResourceLoader.LoadObject<GameUIView>(path);
        _gameUIView = Object.Instantiate(obj, placeForUI);
        AddGameObjects(_gameUIView.gameObject);

        _gameUIView.OnFightRequested += OnFight;
    }

    private void OnFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
    }
}