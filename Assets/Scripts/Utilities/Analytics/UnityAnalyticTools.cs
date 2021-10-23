using System.Collections.Generic;

namespace Utilities.Analytics
{
    public class UnityAnalyticTools : IAnalyticUtility
    {
        public void SendMessage(string alias, IDictionary<string, object> eventData = null)
        {
            if (eventData == null)
                eventData = new Dictionary<string, object>();
            UnityEngine.Analytics.Analytics.CustomEvent(alias, eventData);
        }
    }
}