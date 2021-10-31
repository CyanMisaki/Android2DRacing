using System.Collections.Generic;

namespace Inventory.Items
{
    public interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}