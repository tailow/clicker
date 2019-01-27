using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameManagement manager;
    public GameObject button;
    public GameObject store;

    public void ExitGame()
    {
        int currentTicks = (int)DateTime.Now.Ticks;

        PlayerPrefs.SetInt("exitTicks", currentTicks);
        PlayerPrefs.SetInt("clickCount", manager.clickCount);
        PlayerPrefs.SetInt("clicksPerMin", manager.clicksPerMin);

        Application.Quit();
    }

    public void OpenStore()
    {
        button.SetActive(!button.activeSelf);
        store.SetActive(!store.activeSelf);
    }

    public void Click()
    {
        manager.clickCount += 1;
    }
}
