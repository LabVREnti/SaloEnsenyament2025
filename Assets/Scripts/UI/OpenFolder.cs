using UnityEngine;

public class OpenFolder : MonoBehaviour
{
    public GameObject folderPrefab;
    public Transform folderParent;

    public void OpenFolderWindow()
    {
        Instantiate(folderPrefab, folderParent);
    }
}
