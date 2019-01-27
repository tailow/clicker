using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [HideInInspector]
    public int clickCount;

    [HideInInspector]
    public int clicksPerMin;

    public Text clickCounter;
    public Text clicksPerMinCounter;

    float clickTime;

    void Start()
    {
        if (PlayerPrefs.GetInt("firstTime") == 0)
        {
            int currentTicks = (int)DateTime.Now.Ticks;

            PlayerPrefs.SetInt("exitTicks", currentTicks);
            PlayerPrefs.SetInt("clickCount", 0);
            PlayerPrefs.SetInt("clicksPerMin", 0);

            PlayerPrefs.SetInt("firstTime", 1);
        }

        clicksPerMin = PlayerPrefs.GetInt("clicksPerMin");

        int passedTicks = (int)DateTime.Now.Ticks - PlayerPrefs.GetInt("exitTicks");

        float passedMinutes = (float)TimeSpan.FromTicks(passedTicks).TotalMinutes;

        int passedClicks = (int)(passedMinutes * clicksPerMin);

        clickCount = PlayerPrefs.GetInt("clickCount") + passedClicks;

        clickCounter.text = clickCount.ToString();
    }

    void Update()
    {
        clicksPerMinCounter.text = clicksPerMin.ToString() + " clicks/min";
        clickCounter.text = clickCount.ToString();

        if (clicksPerMin == 0)
            return;

        float clickRate = 60f / clicksPerMin;

        if (Time.time - clickTime == Time.deltaTime)
        {
            clickTime = Time.time;

            clickCount += (int)(Time.deltaTime / clickRate);
        }

        else if (Time.time - clickTime >= clickRate)
        {
            clickTime = Time.time;

            clickCount += 1;
        }
    }
}
