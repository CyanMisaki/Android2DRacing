using System.Collections.Generic;

namespace Utilities.Analytics
{
    public interface IAnalyticUtility
    {
        void SendMessage(string alias, IDictionary<string, object> eventData = null);
    }
}