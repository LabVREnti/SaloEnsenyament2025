using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class DayTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
