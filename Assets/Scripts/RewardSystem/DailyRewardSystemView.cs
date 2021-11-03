using UnityEngine;

namespace RewardSystem
{
    public class DailyRewardSystemView : MonoBehaviour
    {
        [field: SerializeField] public CurrencyView _currencyView { get; }
        [field: SerializeField] public DailyRewardView _dailyRewardView { get; }
    }
}
