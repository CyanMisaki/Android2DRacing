using Inventory;
using UnityEngine;

namespace Abilities
{
    public class AbilityConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _item;
        [SerializeField] private float _abilityPower;
        [SerializeField] private AbilityType _type;
        [SerializeField] private GameObject _view;
        
        public int Id =>_item.ID;
        public float Power => _abilityPower;
        public AbilityType Type => _type;
    }
}