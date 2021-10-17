using Profile;
using Tools;
using UnityEditorInternal.Profiling.Memory.Experimental;
using Utilities.Analytics;
using Utilities.Shop;

public class ProfilePlayer
{
    
    public SubscriptionProperty<GameState> CurrentState { get; }
 
     public Car CurrentCar { get; }
     public int Gold { get; private set; }

     public IAnalyticUtility Analytics { get; }
     //public IShop Shop { get; }
     
    public ProfilePlayer(float speedCar, IAnalyticUtility analytics, int gold/*, IShop shop*/)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speedCar);
        Analytics = analytics;
        Gold = gold;
       // Shop = shop;
    }

    public void AddReward(int summ)
    {
        Gold += summ;
    }

    
}

