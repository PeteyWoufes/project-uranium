using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pauseMenu : MonoBehaviour {
    public bool isPaused;
    public GameObject pauseMenuUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PauseCheck();
	}

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused) { 
            Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        }   

        if (isPaused == false)
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
