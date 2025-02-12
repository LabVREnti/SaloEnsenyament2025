using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class VideoLenguage : MonoBehaviour
{
    LanguageManager manager;
    [SerializeField] List<VideoClip> videos;
    VideoClip video;
    void Start()
    {
        manager = FindAnyObjectByType<LanguageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLanguage();
    }

    void ChangeLanguage()
    {
        switch (manager.GetCurrentLanguage())
        {
            case 0:
                video = videos[0];
                break;
            case 1:
                video = videos[1];
                break;
            case 2:
                video = videos[2];
                break;
            default:

                break;
        }
    }
    public VideoClip GetVideo()
    {
        return video;
    }
}
