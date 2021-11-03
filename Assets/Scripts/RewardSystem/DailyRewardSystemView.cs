using UnityEngine;

namespace RewardSystem
{
    public class DailyRewardSystemView : MonoBehaviour
    {
        [field: SerializeField] public MVCCurrencyView _currencyView { get; }
        [field: SerializeField] public DailyRewardView _dailyRewardView { get; }
    }
}
