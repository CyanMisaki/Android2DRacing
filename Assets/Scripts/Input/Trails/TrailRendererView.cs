using Tools;
using UnityEngine;

public abstract class TrailRendererView : MonoBehaviour
{
    private SubscriptionProperty<Vector3> _tapPosition;        

    public virtual void Init(SubscriptionProperty<Vector3> position)
    {
        _tapPosition = position;
        _tapPosition.SubscribeOnChange(OnSwipe);
    }
    
    protected void OnDestroy()
    {
        _tapPosition?.UnSubscriptionOnChange(OnSwipe);
    }

    protected void OnSwipe(Vector3 value)
    {
        transform.position = value;
    }
    
    
}