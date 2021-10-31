using Car;
using InGameUI;
using Tools;
using UnityEngine;

public class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer, Transform placeForUI)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();
        var tapPosition = new SubscriptionProperty<Vector3>();
        
        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);
        
        var trailRendererController = new TrailRendererController(tapPosition);
        AddController(trailRendererController);
        
        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        AddController(inputGameController);
            
        var carController = new CarController();
        AddController(carController);

        var goldUIController = new InGameUIGoldController(profilePlayer.Gold, placeForUI);
        AddController(goldUIController);
    }
}

