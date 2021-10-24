using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu (fileName = "Upgrade Item", menuName = "Upgrade Items")]
    public class UpgradeItem : ScriptableObject
    {
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField] private float _valueUpgrade;

        public int ID => _itemConfig.ID;
        public ItemConfig ItemConfig => _itemConfig;
        public UpgradeType UpgradeType => _upgradeType;
        public float ValueUpgrade => _valueUpgrade;

    }

    public enum UpgradeType
    {
        None,
        Speed,
        Control,
    }
}