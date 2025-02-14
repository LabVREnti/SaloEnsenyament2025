using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerHandler : MonoBehaviour
{
    public VideoPlayer playerRef;
    public Slider durationBar;
    public Slider volumeBar;
    private bool isPlaying;
    public AudioSource audioSource;

    public enum PlayerState
    {
        PLAYING,
        GRABBED,
        RELEASED
    }
    public PlayerState State { get; set; }

    private void Start()
    {
        isPlaying = true;
        if(!GameManager.Instance.TryPlayVideo(playerRef))
        {
            isPlaying = false;
            Destroy(gameObject);
        }
        State = PlayerState.PLAYING;
        durationBar.maxValue = (float)playerRef.length;
        durationBar.value = durationBar.minValue;

        volumeBar.onValueChanged.AddListener(ForceVolume);
    }

    private void Update()
    {
        switch (State)
        {
            case PlayerState.PLAYING:
                durationBar.value = (float)playerRef.time;
                break;
            case PlayerState.GRABBED:
                break;
            case PlayerState.RELEASED:
                State = PlayerState.PLAYING;
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
        audioSource.volume = newVal;
        audioSource.mute = newVal < Mathf.Epsilon;
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
