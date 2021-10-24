using Car;

namespace Inventory.Garage
{
    public class SpeedUpgradeCarHandler : IUpgradeCarHandler
    {
        private float _speed;

        public SpeedUpgradeCarHandler(float speed)
        {
            _speed = speed;
        }
        
        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            upgradableCar.Speed = _speed;
            return upgradableCar;
        }

        public IUpgradableCar Restore(IUpgradableCar upgradableCar)
        {
            upgradableCar.Speed = upgradableCar.DefaultSpeed;
            return upgradableCar;
        }

        
    }
}