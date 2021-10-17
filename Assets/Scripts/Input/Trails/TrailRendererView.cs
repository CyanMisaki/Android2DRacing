using Tools;
using UnityEngine;

public class TrailRendererView : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trailRenderer;
    private IReadOnlySubscriptionProperty<Vector3> _tapPosition;        

    public void Init(IReadOnlySubscriptionProperty<Vector3> position)
    {
        _tapPosition = position;
        _tapPosition.SubscribeOnChange(OnSwipe);
    }
    
    protected void OnDestroy()
    {
        _tapPosition?.SubscribeOnChange(OnSwipe);
    }
    
    private void OnSwipe(Vector3 value)
    {
        _trailRenderer.transform.position = value;
    }
}