using System;
using System.Collections.Generic;

namespace Inventory.Garage
{
    public class UpgradeHandlersRepository : BaseController
    {
        private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();
        public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;

        public UpgradeHandlersRepository(List<UpgradeItem> upgradeItems)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItems);
        }

        protected override void OnDispose()
        {
            _upgradeItemsMapById.Clear();
            _upgradeItemsMapById = null;
        }

        private void PopulateItems(ref Dictionary<int, IUpgradeCarHandler> upgradeCarHandlersByType,
            List<UpgradeItem> configs)
        {
            foreach (var config in configs)
            {
                if(upgradeCarHandlersByType.ContainsKey(config.ID))
                    return;
                upgradeCarHandlersByType.Add(config.ID, CreateHandlerByType(config));
            }
        }

        private IUpgradeCarHandler CreateHandlerByType(UpgradeItem config)
        { 
            switch (config.UpgradeType)
            {
                case UpgradeType.None:
                    return StubUpgradeCarHandler.Default;
                
                case UpgradeType.Speed:
                    return new SpeedUpgradeCarHandler(config.ValueUpgrade);
                
                case UpgradeType.Control:
                    return StubUpgradeCarHandler.Default;
                
                default:
                    return StubUpgradeCarHandler.Default;
            }
        }
    }
}