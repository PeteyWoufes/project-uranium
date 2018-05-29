using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugMenu : MonoBehaviour {
    private bool debugEnabled;
    private bool invinicibilityEnabled;
    public Collider2D playerCollider;
    public EnemyManager enemyManager;
    public GameObject debugMenuUI;
    
	// Use this for initialization
	void Start () {
        debugEnabled = false;
        invinicibilityEnabled = false;
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


        if (invinicibilityEnabled)
        {
            playerCollider.enabled = false;
        }
        else
        {
            playerCollider.enabled = true;
        }
    }
    
    public void ResetHighScore()
    {
        enemyManager.highestKillCount = 0;
        PlayerPrefs.SetInt(key:enemyManager.highScoreKey, value:enemyManager.enemyKillCount);
        PlayerPrefs.Save();
    }

    public void ToggleInvincibility()
    {
        invinicibilityEnabled = !invinicibilityEnabled;
    }
}
