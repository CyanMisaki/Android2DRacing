using Tools;
using UnityEngine;

public class TrailRendererController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/TrailRenderer"};
    private TrailRendererView _view;
    private readonly SubscriptionProperty<Vector3> _position;
    
    public TrailRendererController()
    {
        _view = LoadView();
        _position = new SubscriptionProperty<Vector3>();
        _position.Value = new Vector3(0, 0, -1);
        _view.Init(_position);
    }
    
    
    
    protected override void OnDispose()
    {
        _position.UnSubscriptionOnChange(Move);
        base.OnDispose();
    }
    private TrailRendererView LoadView()
    {
        var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);
        
        return objView.GetComponent<TrailRendererView>();
    }


    public void Move(Vector3 position)
    {
        _position.Value = position;
    }
}