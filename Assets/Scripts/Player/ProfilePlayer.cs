using System;
using Profile;
using Tools;

using Utilities.Analytics;
using Utilities.Shop;

public class ProfilePlayer
{
    
    public SubscriptionProperty<GameState> CurrentState { get; }
    public SubscriptionProperty<int> Gold { get; }

     public Car.Car CurrentCar { get; }
     
     public IAnalyticUtility Analytics { get; }
     
     
     public PlayerPrefsSubscriptionProperty<int> Wood { get; }
     public PlayerPrefsSubscriptionProperty<int> Diamond { get; }
     
     
     public PlayerPrefsSubscriptionProperty<float> Health { get; }
     public PlayerPrefsSubscriptionProperty<int> Money { get; }
     public PlayerPrefsSubscriptionProperty<float> Power { get; }
     public PlayerPrefsSubscriptionProperty<int> Pursuit { get; }
     
    public ProfilePlayer(float speedCar, IAnalyticUtility analytics /*, IShop shop*/)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car.Car(speedCar);
        Analytics = analytics;
        Gold = new SubscriptionProperty<int>();

        Wood = new PlayerPrefsSubscriptionProperty<int>(nameof(Wood));
        Diamond = new PlayerPrefsSubscriptionProperty<int>(nameof(Diamond));

        Health = new PlayerPrefsSubscriptionProperty<float>(nameof(Health));
        Money = new PlayerPrefsSubscriptionProperty<int>(nameof(Money));
        Power = new PlayerPrefsSubscriptionProperty<float>(nameof(Power));
        Pursuit = new PlayerPrefsSubscriptionProperty<int>(nameof(Pursuit));

        Wood.Value = 0;
        Diamond.Value = 0;

        Health.Value = 0;
        Money.Value = 0;
        Power.Value = 0;
        Pursuit.Value = 0;
    }

    public void AddReward(int summ)
    {
        Gold.Value += summ;
    }
}

