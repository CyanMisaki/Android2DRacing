using System;
using JoostenProductions;
using Tools;
using UnityEngine;

public class TapScreenAcceleration : BaseInputView
{
    private readonly float _direction = Vector3.right.sqrMagnitude;
    private readonly float _halfScreenWidth = Screen.width / 2.0f;
    
    private Touch _touch;

    
    public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
    {
        base.Init(leftMove, rightMove, speed);
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

        if (_touch.position.x > _halfScreenWidth)
        {
            OnRightMove(_direction / 200 * _speed);
        }

        else if (_touch.position.x <= _halfScreenWidth)
        {
            OnLeftMove(-_direction / 200 * _speed);
        }
    }
}