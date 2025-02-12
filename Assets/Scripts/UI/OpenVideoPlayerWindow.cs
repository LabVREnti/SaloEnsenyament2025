using UnityEngine;
using UnityEngine.Video;

public class OpenVideoPlayerWindow : MonoBehaviour
{
    public GameObject folderPrefab;
    public Transform folderParent;

    public VideoLenguage videoLenguageRef;

    public void OpenNewPlayerWindow()
    {
        if (GameManager.Instance.TryOpenWindow())
        {
            GameObject playerWindow = Instantiate(folderPrefab, folderParent ? folderParent : GameManager.Instance.DesktopTr);
            playerWindow.GetComponentInChildren<VideoPlayer>(true).clip = videoLenguageRef.GetVideo();
        }
    }
}
