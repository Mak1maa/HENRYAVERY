using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakeCoins : MonoBehaviour
{
    public static int coinsCount;
    private Text coinsConter;

    void Start()
    {
        coinsConter = GetComponent<Text>();
        //coinsCount = 0;
    }

    void Update()
    {
        coinsConter.text = "COINS " + coinsCount;
    }
}