using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TextMeshProUGUI>().text = "COINS: " + coinCount;
    }
}
