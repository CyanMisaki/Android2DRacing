using JoostenProductions;
using Tools;
using UnityEngine;

public class DrawTrails : TrailRendererView
{
    private Vector3 _swipePosition;
    private Camera _camera;
    private Touch _touch;

    public override void Init(SubscriptionProperty<Vector3> position)
    {
        _camera=Camera.main; 
        base.Init(position);
        UpdateManager.SubscribeToUpdate(Move);
    }

    private void OnDestroy()
    {
        UpdateManager.UnsubscribeFromUpdate(Move);
    }
    
    private void Move()
    {
        if (Input.touchCount <= 0) return;
        
        _touch = Input.GetTouch(0);

        if (_touch.phase != TouchPhase.Moved) return;
        _swipePosition = _camera.ScreenToWorldPoint(_touch.position);
        _swipePosition.z = -1;
        OnSwipe(_swipePosition);
    }
}