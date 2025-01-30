using NUnit.Framework;
using System.Numerics;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLanguage : MonoBehaviour
{
    LanguageManager manager;
    [SerializeField] List<string> languages;
    [SerializeField] TextMeshProUGUI text;
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
                text.text = languages[0];
                break;
            case 1:
                text.text = languages[1];
                break;
            case 2:
                text.text = languages[2];
                break;
            default:

                break;
        }
    }
}
