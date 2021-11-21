using UnityEngine;

namespace RewardSystem
{
    public class RewardSystemRoot : MonoBehaviour
    {
        [SerializeField] private DailyRewardView _dailyRewardView;

        private DailyRewardController _dailyRewardController;

        private void Awake()
        {
            //_dailyRewardController = new DailyRewardController(_dailyRewardView);
        }

        private void Start()
        {
            _dailyRewardController.RefreshView();
        }
    }
}
