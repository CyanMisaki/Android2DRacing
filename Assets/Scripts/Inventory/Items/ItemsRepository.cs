using System.Collections.Generic;

namespace Inventory.Items
{
    public class ItemsRepository : BaseController, IItemsRepository
    {
        private Dictionary<int, IItem> _itemsMapByID = new Dictionary<int, IItem>();
        
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapByID;


        public ItemsRepository(List<ItemConfig> upgradeItem)
        {
            PopulateItems(ref _itemsMapByID, upgradeItem);
        }

        protected override void OnDispose()
        {
            _itemsMapByID.Clear();
            _itemsMapByID = null;
        }

        private void PopulateItems(ref Dictionary<int, IItem> upgradeHandlersMapByType, List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.ID))
                    continue;
                upgradeHandlersMapByType.Add(config.ID,CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config) 
        {
            return new Item
            {
                ID = config.ID,
                Info = new ItemInfo { Title = config.Title }
            };
        }
    }
}