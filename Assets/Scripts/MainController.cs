using System;
using System.Collections.Generic;
using Inventory;
using Inventory.Garage;
using Inventory.PlayerInventory;
using Profile;
using RewardSystem;
using UnityEngine;
using Utilities.Ads;

public class MainController : BaseController
{
    private ResourcePath RewardViewPath = new ResourcePath() { PathResource = "Prefabs/DailyRewardWindow" };
    
     private MainMenuController _mainMenuController;
     private GameController _gameController;
     private InventoryController _inventoryController;
     private GarageController _garageController;
     private DailyRewardController _dailyRewardController;
     
     private readonly Transform _placeForUi;
     private readonly ProfilePlayer _profilePlayer;
     private readonly IAdsShower _adsShower;
     private readonly List<ItemConfig> _itemConfigs;
     private readonly List<UpgradeItem> _upgradeItems;
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower, List<ItemConfig> itemConfigs, List<UpgradeItem> upgradeItems)
    {
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        _itemConfigs = itemConfigs;
        _upgradeItems = upgradeItems;
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
                _gameController?.Dispose();
                _garageController?.Dispose();
                _dailyRewardController?.Dispose();
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _adsShower);
                break;
            
            case GameState.Game:
                _profilePlayer.Analytics.SendMessage("GameStarted", new Dictionary<string, object>());
                
                _inventoryController = new InventoryController(_itemConfigs);
                _inventoryController.ShowInventory();
                
                _gameController = new GameController(_profilePlayer, _placeForUi);
                _mainMenuController?.Dispose();
                _garageController?.Dispose();
                _dailyRewardController?.Dispose();
                break;
            
            case GameState.Shop:
                //TODO ShopController
                break;
            
            case GameState.Garage:
                _garageController = new GarageController(_placeForUi, _upgradeItems, _profilePlayer.CurrentCar, _profilePlayer);
                _garageController.Enter();
                
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _dailyRewardController?.Dispose();
                break;

            case GameState.DailyReward:
                _gameController?.Dispose();
                _mainMenuController?.Dispose();
                _garageController?.Dispose();
                _inventoryController?.Dispose();
                _dailyRewardController = new DailyRewardController(_profilePlayer, RewardViewPath, _placeForUi);
                break;
            
            case GameState.Fight:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _garageController?.Dispose();
                _inventoryController?.Dispose();
                _dailyRewardController?.Dispose();
                break;
            
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _garageController?.Dispose();
                _inventoryController?.Dispose();
                _dailyRewardController?.Dispose();
                break;
        }
    }
}
