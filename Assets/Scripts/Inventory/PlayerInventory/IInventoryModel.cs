using System.Collections.Generic;
using Inventory.Items;

namespace Inventory.PlayerInventory
{
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnEquipItem(IItem item);
    }
}