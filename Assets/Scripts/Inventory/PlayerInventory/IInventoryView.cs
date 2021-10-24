using System.Collections.Generic;
using Inventory.Items;

namespace Inventory.PlayerInventory
{
    public interface IInventoryView
    {
        void Display(IReadOnlyList<IItem> items);
    }
}