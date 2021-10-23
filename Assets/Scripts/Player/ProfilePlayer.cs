using System;
using Profile;
using Tools;
using UnityEditorInternal.Profiling.Memory.Experimental;
using Utilities.Analytics;
using Utilities.Shop;

public class ProfilePlayer
{
    
    public SubscriptionProperty<GameState> CurrentState { get; }
    public SubscriptionProperty<int> Gold { get; }

     public Car CurrentCar { get; }
     
     public IAnalyticUtility Analytics { get; }
     //public IShop Shop { get; }
     
    public ProfilePlayer(float speedCar, IAnalyticUtility analytics /*, IShop shop*/)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speedCar);
        Analytics = analytics;
        Gold = new SubscriptionProperty<int>();

        // Shop = shop;
    }

    public void AddReward(int summ)
    {
        Gold.Value += summ;
    }
}

