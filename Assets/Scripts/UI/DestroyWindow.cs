using UnityEngine;

public class DestroyWindow : MonoBehaviour
{
    public GameObject windowObj;
    public void DestroyExistingWindow()
    {
        GameManager.Instance.WindowClosed();
        Destroy(windowObj);
    }
}
