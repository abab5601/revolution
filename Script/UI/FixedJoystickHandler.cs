using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FixedJoystickHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{

    [System.Serializable]
    public class VirtualJoystickEvent : UnityEvent<Vector2,bool> { }
    public Transform content;
    public VirtualJoystickEvent controlling;

    public void OnDrag(PointerEventData eventData)
    {

        if (this.content)
        {
            this.controlling.Invoke(this.content.localPosition.normalized,false);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (this.content)
        {
            this.controlling.Invoke(this.content.localPosition.normalized,true);
        }

    }
}