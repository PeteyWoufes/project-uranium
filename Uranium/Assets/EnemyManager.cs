﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public bulletShooter bS;
    public GameObject[] enemy;
    public enemyAI enemyAI;
    public float spawnTime = 3f;
    public float difficultyMultiplier;
    public Transform[] spawnPoints;
    public int enemyKillCount;
    public Text score;
    public Text highScore;
    public int highestKillCount;
    public float difficultyNumber;
    public string highScoreKey = "HighScore";
    public float eventTimer;

    void Start () {
        eventTimer = 0;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        highestKillCount = PlayerPrefs.GetInt(highScoreKey, 0);
    }
	
	void Spawn () {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int enemySpawnIndex = Random.Range(0, enemy.Length);
        Instantiate(enemy[enemySpawnIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

    void ScoreCheck()
    {
        score.text = "Kills: " + enemyKillCount;
        highScore.text = "High score: " + highestKillCount;
        if (enemyKillCount > highestKillCount)
        {
            PlayerPrefs.SetInt(highScoreKey, enemyKillCount);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        ScoreCheck();
        DifficultyCheck();
        EventCheck();
    }

    void DifficultyCheck()
    { 
        if (difficultyNumber > 12)
        {
            spawnTime *= 0.95f;
            enemyAI.speed *= difficultyMultiplier;
            difficultyNumber = 0;
        }
        
    }

    void EventCheck()
    {
        eventTimer += Time.deltaTime;
        if (eventTimer >= 25)
        {
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Debug.Log("eventTimer = 25; resetting to 0");
            eventTimer = 0;
        }
    }
}
