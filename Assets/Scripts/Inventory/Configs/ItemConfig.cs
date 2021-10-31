using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu (fileName = "Item", menuName = "Items")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _title;

        public int ID => _id;
        public string Title => _title;

    }
}