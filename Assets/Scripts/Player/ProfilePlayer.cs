using Profile;
using Tools;
using UnityEditorInternal.Profiling.Memory.Experimental;
using Utilities.Analytics;

public class ProfilePlayer
{
    public SubscriptionProperty<GameState> CurrentState { get; }
 
     public Car CurrentCar { get; }
     
     public int Gold { get;  }
 
     public IAnalyticUtility Analytics { get; }
    public ProfilePlayer(float speedCar, IAnalyticUtility analytics, int gold)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speedCar);
        Analytics = analytics;
        Gold = gold;
    }

    
}

