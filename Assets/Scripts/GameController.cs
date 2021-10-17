using Tools;

public class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();
        
        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);
        
        var trailRendererController = new TrailRendererController();
        AddController(trailRendererController);
        
        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar, trailRendererController);
        AddController(inputGameController);
            
        var carController = new CarController();
        AddController(carController);

        
    }
}

