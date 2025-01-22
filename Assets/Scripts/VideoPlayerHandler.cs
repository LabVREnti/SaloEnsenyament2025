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

    public void FastForward()
    {
        playerRef.time += 5f; //time in seconds
    }
    public void Rewind()
    {
        playerRef.time -= 5f; //time in seconds
    }

    public void SwitchPlay()
    {
        if(isPlaying)
        {
            isPlaying = false;
            playerRef.playbackSpeed = 0f;
        }
        else
        {
            isPlaying = true;
            playerRef.playbackSpeed = 1f;
        }
    }
}
