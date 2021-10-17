using System;

namespace Utilities.Ads
{
    public interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action onSuccess);
    }
}