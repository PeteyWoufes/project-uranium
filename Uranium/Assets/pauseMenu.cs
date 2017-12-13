using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour {
    public bool isPaused;
    public GameObject pauseMenuUI;
    public playerScript pS;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PauseCheck();
	}

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pS.deathTimer <= 2.2f)
        {
            isPaused = !isPaused;
        }

        if (isPaused) { 
            Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        }   

        if (isPaused == false)
        {
            if (pS.deathTimer <= 2.2f) {
                Time.timeScale = 1;
            }
            
            pauseMenuUI.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
