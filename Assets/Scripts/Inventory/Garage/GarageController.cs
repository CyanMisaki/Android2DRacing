using System.Collections.Generic;
using System.Linq;
using Car;
using Inventory.Items;
using Inventory.PlayerInventory;
using JetBrains.Annotations;
using Profile;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Inventory.Garage
{
    public class GarageController : BaseController, IShedController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/garageMenu"};
        private readonly GarageView _view;
        
        private readonly Car.Car _car;
        
        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly InventoryModel _inventoryModel;
        private readonly ProfilePlayer _profilePlayer;

        public GarageController(Transform placeForUi, [NotNull] List<UpgradeItem> upgradeItem, [NotNull] Car.Car car, ProfilePlayer profilePlayer)
        {
            _car = car;
            _profilePlayer = profilePlayer;
            
            _upgradeHandlersRepository = new UpgradeHandlersRepository(upgradeItem);
            AddController(_upgradeHandlersRepository);

            _upgradeItemsRepository = new ItemsRepository(upgradeItem.Select(value => value.ItemConfig).ToList());
            AddController(_upgradeItemsRepository);

            _inventoryModel = new InventoryModel();

            _view = LoadView(placeForUi);
        }
        
        private GarageView LoadView(Transform placeForUi)
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
        
            return objectView.GetComponent<GarageView>();
        }
        
        public void Enter()
        {
            Debug.Log($"Enter garage: Car has speed: {_car.Speed}");
            
            _view.Init(_upgradeItemsRepository, EquipItem ,Exit);
        }

       public void EquipItem(IItem item)
        {
            _inventoryModel.EquipItem(item);
            Debug.Log($"Item Equipped: Car speed has increased by {item.Info.Title}");
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(_car, _inventoryModel.GetEquippedItems(),
                _upgradeHandlersRepository.UpgradeItems);
            Debug.Log($"Exit garage: Car has speed: {_car.Speed}");
            _profilePlayer.CurrentState.Value = GameState.Game;
        }

        private void UpgradeCarWithEquippedItems(IUpgradableCar car, IReadOnlyList<IItem> equippedItems, IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.ID, out var handler))
                    handler.Upgrade(car);
            }
        }
    }
}