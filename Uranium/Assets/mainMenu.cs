using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit button pressed.");
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play button pressed.");
    }
}
