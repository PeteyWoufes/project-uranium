using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public bulletShooter bS;
    public GameObject[] enemy;
    public enemyAI enemyAI;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int enemyKillCount;
    public Text score;
    public Text highScore;
    public int highestKillCount;
    public float difficultyNumber;
    public string highScoreKey = "HighScore";

    void Start () {
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
    }

    void DifficultyCheck()
    { 
        if (difficultyNumber > 12)
        {
            spawnTime *= 0.95f;
            enemyAI.speed *= 1.15f;
            difficultyNumber = 0;
        }
    }
}
