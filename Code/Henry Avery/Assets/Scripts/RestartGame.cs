using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void ResetGame()
    {
        PlayerPrefs.DeleteKey("SaveDeaths");
        HowManyDeaths.deathsCount = 0;
        Stopwatch.mSeconds = 0;
        Stopwatch.seconds = 0;
        Stopwatch.minutes = 0;
    }
}