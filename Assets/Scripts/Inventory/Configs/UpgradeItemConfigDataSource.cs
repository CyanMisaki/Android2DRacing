using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu (fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource")]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItem[] _itemConfigs;

        private UpgradeItem[] ItemConfigs => _itemConfigs;
    }
}