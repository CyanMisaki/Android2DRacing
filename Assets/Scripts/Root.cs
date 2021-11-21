using System.Collections.Generic;
using Inventory;
using Profile;
using UnityEngine;
using Utilities.Ads;
using Utilities.Analytics;
using Utilities.Shop;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private UnityAdsTools _adsTools;
    [SerializeField] private ShopUtility _shopUtility;
    [SerializeField] private List<ItemConfig> _itemConfigs;
    [SerializeField] private List<UpgradeItem> _upgradeItems;

    private MainController _mainController;
   

    private void Awake()
    {
        
        var analytics = new UnityAnalyticTools();
        //TODO ShopProducts
        //var shop = new ShopUtility(products);
        
        var profilePlayer = new ProfilePlayer(15f, analytics/*, shop*/);
        profilePlayer.CurrentState.Value = GameState.Start;
        profilePlayer.Gold.Value = 0;
        
        _mainController = new MainController(_placeForUi, profilePlayer, _adsTools, _itemConfigs, _upgradeItems);
       
        analytics.SendMessage("GameStart", new Dictionary<string, object>());
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}