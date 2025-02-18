using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private short currentWindows;
    public const short MAX_WINDOWS = 6;

    private VideoPlayer currrentPlayer;
    [field:SerializeField] public Transform DesktopTr {  get; private set; }

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

    public bool TryOpenWindow()
    {
        if (currentWindows < MAX_WINDOWS)
        {
            currentWindows++;
            return true;
        }
        return false;
    }

    public void WindowClosed() => currentWindows--;
}
