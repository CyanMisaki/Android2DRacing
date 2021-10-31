using System.Collections.Generic;
using Inventory.Items;

namespace Inventory.PlayerInventory
{
    public class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryWindowView;
        private IReadOnlyList<IItem> _equippedItems;

        public InventoryController(List<ItemConfig> itemConfigs)
        {
            _inventoryModel = new InventoryModel();
            _itemsRepository = new ItemsRepository(itemConfigs);
            _inventoryWindowView = new InventoryView();
        }

        public void ShowInventory()
        {
            foreach (var item in _itemsRepository.Items.Values)
            {
                _inventoryModel.EquipItem(item);

                _equippedItems = _inventoryModel.GetEquippedItems();
                _inventoryWindowView.Display(_equippedItems);
            }
        }
        
        
        
    }
}