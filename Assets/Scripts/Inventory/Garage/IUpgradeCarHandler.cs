using Car;

namespace Inventory.Garage
{
    public interface IUpgradeCarHandler
    {
        IUpgradableCar Upgrade(IUpgradableCar upgradableCar);
        IUpgradableCar Restore(IUpgradableCar upgradableCar);
    }
}