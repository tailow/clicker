using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Editor : MonoBehaviour
{
    [MenuItem("Custom/Reset")]
    static void ResetGame()
    {
        PlayerPrefs.SetInt("firstTime", 0);
    }
}
