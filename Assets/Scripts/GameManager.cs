using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private VideoPlayer currrentPlayer;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public bool TryPlayVideo(VideoPlayer player)
    {
        if (currrentPlayer == null)
        {
            currrentPlayer = player;
            player.Play();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ClearCurrentPlayer()
    {
        currrentPlayer = null;
    }
}
