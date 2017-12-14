using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public GameObject[] enemy;
    public enemyAI enemyAI;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int enemyKillCount;
    public Text score;
    public Text highScore;
    public int highestKillCount;
    public float difficultyNumber;
    string highScoreKey = "HighScore";
    // Use this for initialization
    void Start () {

        InvokeRepeating("Spawn", spawnTime, spawnTime);
        highestKillCount = PlayerPrefs.GetInt(highScoreKey, 0);


    }
	
	// Update is called once per frame
	void Spawn () {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int enemySpawnIndex = Random.Range(0, enemy.Length);

        Instantiate(enemy[enemySpawnIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

    void ScoreCheck()
    {
        score.text = "Enemies killed: " + enemyKillCount;
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
            spawnTime *= 0.80f;
            enemyAI.speed *= 1.2f;
            difficultyNumber = 0;
           
        }

        

    }

    private void OnDisable()
    {
       
    }
}
