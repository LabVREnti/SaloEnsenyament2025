using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerHandler : MonoBehaviour
{
    public VideoPlayer playerRef;
    public Slider durationBar;
    private bool isPlaying;

    private void OnEnable()
    {
        if(!GameManager.Instance.TryPlayVideo(playerRef))
        {
            isPlaying = false;
            Destroy(gameObject);
        }
        durationBar.maxValue = (float)playerRef.length;
        durationBar.value = durationBar.minValue;
        durationBar.onValueChanged.AddListener(ForceTimePosition);
    }

    private void Update()
    {
        durationBar.value = (float)playerRef.time;
    }

    private void OnDestroy()
    {
        if(isPlaying)
        {
            GameManager.Instance.ClearCurrentPlayer();
        }
    }

    private void ForceTimePosition(float newVal)
    {
        playerRef.time = newVal;
    }

}
