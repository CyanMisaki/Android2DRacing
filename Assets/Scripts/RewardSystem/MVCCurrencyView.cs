using UnityEngine;
using UnityEngine.UI;

namespace RewardSystem
{
    public class MVCCurrencyView : MonoBehaviour
    {
        [SerializeField] private Text _currentWoodCount;
        [SerializeField] private Text _currentDiamondCount;
        
        public int Wood
        {
            set => _currentWoodCount.text = value.ToString();
        }
        public int Diamond
        {
            set => _currentDiamondCount.text = value.ToString();
        }
    }
}