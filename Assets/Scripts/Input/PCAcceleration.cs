using JoostenProductions;
using Tools;
using UnityEngine;

public class PCAcceleration : BaseInputView
{
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
        var direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");

        if (direction.x > 0)
        {
             if (direction.sqrMagnitude > 1)
                        direction.Normalize();
             OnRightMove(direction.sqrMagnitude / 200 * _speed);
        }

        else if (direction.x < 0)
        {
            if (direction.sqrMagnitude > 1)
                direction.Normalize();
            OnLeftMove(-direction.sqrMagnitude / 200 * _speed);
        }
            
    }
}