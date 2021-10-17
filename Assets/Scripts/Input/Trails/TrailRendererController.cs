using Tools;
using UnityEngine;

public class TrailRendererController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/TrailRenderer"};
    private TrailRendererView _view;
    
    public TrailRendererController(SubscriptionProperty<Vector3> position)
    {
        _view = LoadView();
        _view.Init(position);
    }
    
    private TrailRendererView LoadView()
    {
        var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);
        
        return objView.GetComponent<TrailRendererView>();
    }


  
}