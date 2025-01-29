using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerHandler : MonoBehaviour
{
    public VideoPlayer playerRef;
    public Slider durationBar;
    public Slider volumeBar;
    private bool isPlaying;

    private void Start()
    {
        isPlaying = true;
        if(!GameManager.Instance.TryPlayVideo(playerRef))
        {
            isPlaying = false;
            Destroy(gameObject);
        }
        durationBar.maxValue = (float)playerRef.length;
        durationBar.value = durationBar.minValue;
        durationBar.onValueChanged.AddListener(ForceTimePosition);
        Debug.Log(durationBar.maxValue);
        
      

        //volumeBar.value = volumeBar.maxValue = playerRef.GetDirectAudioVolume(0);
        volumeBar.onValueChanged.AddListener(ForceVolume);
    }

    private void Update()
    {
       // durationBar.value = (float)playerRef.time;
        Debug.Log(durationBar.value);
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

    private void ForceVolume(float newVal)
    {
        playerRef.SetDirectAudioVolume(0, newVal);
        playerRef.SetDirectAudioMute(0, newVal < Mathf.Epsilon);
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
