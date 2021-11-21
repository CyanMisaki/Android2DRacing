using UnityEngine;

namespace Tools
{
    public class PlayerPrefsSubscriptionProperty<T> : SubscriptionProperty<T>, IReadOnlySubscriptionProperty<T>
    {
        private readonly string _ppKey;

        public PlayerPrefsSubscriptionProperty(string ppKey)
        {
            _ppKey = ppKey;
            this.Value = Parse(PlayerPrefs.GetString(_ppKey));
            this.SubscribeOnChange(UpdateValue);
        }

        private T Parse(string value)
        {
            return default(T);
        }
        
        private void UpdateValue(T value)
        {
            PlayerPrefs.SetString(_ppKey, value.ToString());
        }
    }
}