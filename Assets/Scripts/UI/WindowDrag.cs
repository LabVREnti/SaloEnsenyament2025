using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDrag : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private RectTransform parent;

    private void Start()
    {
        parent = transform.parent as RectTransform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parent.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        parent.position += (Vector3)eventData.delta;
    }

    
}
