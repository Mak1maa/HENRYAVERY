using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void Back(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}