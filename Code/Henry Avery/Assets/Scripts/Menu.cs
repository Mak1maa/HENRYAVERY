using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Stopwatch.mSeconds = 0;
        Stopwatch.seconds = 0;
        Stopwatch.minutes = 0;
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}