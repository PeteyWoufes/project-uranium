using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pauseMenu : MonoBehaviour {
    public bool isPaused;
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

        if (isPaused)
            Time.timeScale = 0;

        if (isPaused == false)
            Time.timeScale = 1;
    }
}
