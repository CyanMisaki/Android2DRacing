namespace Inventory.Items
{
    public interface IItem
    {
        int ID { get; }

        ItemInfo Info { get; }
    }
}