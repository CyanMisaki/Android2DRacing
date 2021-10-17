using System;

namespace Utilities
{
    public interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscriptionAction);
        void UnSubscriptionOnChange(Action unsubscriptionAction);
    }
}