using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowManyDeaths : MonoBehaviour
{
    public static int deathsCount;
    private Text deathsConter;

    void Start()
    {
        deathsConter = GetComponent<Text>();
        //deathsCount = 0;
    }

    void Update()
    {
        deathsConter.text = "DEATHS " + deathsCount;
    }
}