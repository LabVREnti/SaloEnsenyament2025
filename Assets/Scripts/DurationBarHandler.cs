using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DurationBarHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public VideoPlayerHandler videoPlayerHandlerRef;
    private Slider durationBarRef;

    private void Start()
    {
        durationBarRef = videoPlayerHandlerRef.durationBar;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        videoPlayerHandlerRef.State = VideoPlayerHandler.PlayerState.GRABBED;
        durationBarRef.onValueChanged.AddListener(ForceTimePosition);        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        videoPlayerHandlerRef.State = VideoPlayerHandler.PlayerState.RELEASED;
        durationBarRef.onValueChanged.RemoveListener(ForceTimePosition);
    }

    private void ForceTimePosition(float newVal)
    {
        videoPlayerHandlerRef.videoPlayerRef.time = newVal;
    }
}
