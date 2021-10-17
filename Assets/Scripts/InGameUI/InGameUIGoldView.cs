using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace InGameUI
{
    public class InGameUIView : MonoBehaviour
    {
        [SerializeField] 
        private Text _goldPlace;

        private IReadOnlySubscriptionProperty<int> _gold;

        public void Init(IReadOnlySubscriptionProperty<int> gold)
        {
            _gold = gold;
            _gold.SubscribeOnChange(ChangeGoldStatus);
        }

        protected void OnDestroy()
        {
            _gold?.SubscribeOnChange(ChangeGoldStatus);
        }

        private void ChangeGoldStatus(int value)
        {
            _goldPlace.text = value.ToString();
        }
    


    }
}