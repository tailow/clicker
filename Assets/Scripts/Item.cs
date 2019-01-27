using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int clicksPerMin;
    public int cost;

    public GameManagement manager;

    private void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = clicksPerMin.ToString();
        transform.GetChild(1).GetComponent<Text>().text = "Cost: " + cost.ToString();
    }

    public void BuyItem()
    {
        if (manager.clickCount >= cost)
        {
            manager.clickCount -= cost;
            manager.clicksPerMin += clicksPerMin;
        }
    }
}
