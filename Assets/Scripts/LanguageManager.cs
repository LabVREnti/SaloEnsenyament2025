using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    List<int> languages; //0 = cat ; 1 = eng ; 2 = esp
    int currentLanguage;

    private void Start()
    {
        currentLanguage = 0;
    }

    public void ChangeLanguage(int language)
    {
        currentLanguage = language;
    }

    private void Update()
    {
        Debug.Log(currentLanguage);
    }

    public int GetCurrentLanguage()
    {
        return currentLanguage;
    }
}
