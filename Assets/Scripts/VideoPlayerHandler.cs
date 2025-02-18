using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerHandler : MonoBehaviour
{
    public VideoPlayer videoPlayerRef;
    public Slider durationBar;
    public Slider volumeBar;
    private bool isPlaying;

    public enum PlayerState
    {
        PLAYING,
        PAUSED,
        GRABBED,
        RELEASED
    }
    public PlayerState State { get; set; }

    private void Start()
    {
        isPlaying = true;
        if(!GameManager.Instance.TryPlayVideo(videoPlayerRef))
        {
            isPlaying = false;
            Destroy(gameObject);
        }
        State = PlayerState.PLAYING;
        durationBar.maxValue = (float)videoPlayerRef.length;
        durationBar.value = durationBar.minValue;

        volumeBar.onValueChanged.AddListener(ForceVolume);

        videoPlayerRef.Play();
        videoPlayerRef.frame = 1;
        videoPlayerRef.Pause();
    }

    private void Update()
    {
        switch (State)
        {
            case PlayerState.PLAYING:
                durationBar.value = (float)videoPlayerRef.time;
                break;

            case PlayerState.PAUSED:
            case PlayerState.GRABBED:
                break;

            case PlayerState.RELEASED:
                State = PlayerState.PLAYING;
                durationBar.value = (float)videoPlayerRef.time;
                return; //skip one frame
            
            default: break;
        }
    }

    private void OnDestroy()
    {
        if(isPlaying)
        {
            GameManager.Instance.ClearCurrentPlayer();
        }
    }

    

    private void ForceVolume(float newVal)
    {
        videoPlayerRef.SetDirectAudioVolume(0, newVal);
        videoPlayerRef.SetDirectAudioMute(0, newVal < Mathf.Epsilon);
    }

    public void FastForward()
    {
        videoPlayerRef.time += 5f; //time in seconds
    }
    public void Rewind()
    {
        videoPlayerRef.time -= 5f; //time in seconds
    }

    public void SwitchPlay()
    {
        if(isPlaying)
        {
            isPlaying = false;
            videoPlayerRef.playbackSpeed = 0f;
            State = PlayerState.PAUSED;
        }
        else
        {
            isPlaying = true;
            videoPlayerRef.playbackSpeed = 1f;
            State = PlayerState.PLAYING;
        }
    }
}
