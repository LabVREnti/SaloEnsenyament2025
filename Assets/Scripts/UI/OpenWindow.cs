using UnityEngine;

public class OpenWindow : MonoBehaviour
{
    public GameObject folderPrefab;
    public Transform folderParent;

    public void OpenNewWindow()
    {
        if(GameManager.Instance.TryOpenWindow())
            Instantiate(folderPrefab, folderParent ? folderParent : GameManager.Instance.DesktopTr);
    }
}
