using System.Collections.Generic;
using Profile;
using UnityEngine;
using Utilities.Ads;
using Utilities.Analytics;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private UnityAdsTools _adsTools;

    private MainController _mainController;

    private void Awake()
    {
        
        var analytics = new UnityAnalyticTools();
        var profilePlayer = new ProfilePlayer(15f, analytics,100);
        
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _adsTools);
       
        analytics.SendMessage("GameStart", new Dictionary<string, object>());
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
