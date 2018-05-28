using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugMenu : MonoBehaviour {
    private bool debugEnabled;
    public GameObject debugMenuUI;
    public EnemyManager enemyManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DebugCheck();
	}

    void DebugCheck()
    {
        if ((Input.GetKey(KeyCode.LeftShift)) && (Input.GetKeyDown(KeyCode.D)))
        {
            debugEnabled = !debugEnabled;
        }
        if (debugEnabled)
        {
            debugMenuUI.SetActive(true);
        }
        else
        {
            debugMenuUI.SetActive(false);
        }
    }
    
    public void ResetHighScore()
    {
        enemyManager.highestKillCount = 0;
        PlayerPrefs.SetInt(key:enemyManager.highScoreKey, value:enemyManager.enemyKillCount);
        PlayerPrefs.Save();
    }
}
