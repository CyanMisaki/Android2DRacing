using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace InGameUI
{
    public class InGameUIGoldView : MonoBehaviour
    {
        [SerializeField] 
        private Text _goldPlace;

        private SubscriptionProperty<int> _gold;

        /*public void Init(SubscriptionProperty<int> gold)
        {
            _gold = gold;
            _gold.SubscribeOnChange(ChangeGoldStatus);
            ChangeGoldStatus(_gold.Value);
        }*/

        protected void OnDestroy()
        {
            _gold?.UnSubscriptionOnChange(ChangeGoldStatus);
        }

        public void ChangeGoldStatus(int value)
        {
            _goldPlace.text = $"{value.ToString()} G";
        }
    


    }
}