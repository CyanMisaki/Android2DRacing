using System.Collections.Generic;
using Profile;
using UnityEngine;
using Utilities.Analytics;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    private MainController _mainController;

    private void Awake()
    {
        var analytics = new UnityAnalyticTools();
        var profilePlayer = new ProfilePlayer(15f, analytics);
        
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer);
       
        analytics.SendMessage("GameStart", new Dictionary<string, object>());
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
