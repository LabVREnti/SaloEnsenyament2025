using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDrag : MonoBehaviour, IDragHandler
{
    private RectTransform parent;

    private void Start()
    {
        parent = transform.parent as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        parent.position += (Vector3)eventData.delta;
    }

    
}
