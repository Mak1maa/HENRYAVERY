using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stopwatch : MonoBehaviour
{
    public static int mSeconds;
    public static int seconds;
    public static int minutes;

    public Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    
    private void FixedUpdate()
    {
        mSeconds += 1;

        if(mSeconds == 50)
        {
            seconds++;
            mSeconds = 0;
        }

        if(seconds == 60)
        {
            minutes++;
            seconds = 0;
        }
    }
    
    public void Update()
    {
        text.text = $"{minutes} : {seconds} : {mSeconds}" + " - TIME";
    }
}