using Inventory.Items;

namespace Inventory.Garage
{
    public interface IShedController
    {
        void Enter();
        void EquipItem(IItem item);
        void Exit();
    }
}