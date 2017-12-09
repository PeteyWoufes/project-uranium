using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public GameObject enemy;
    public enemyAI enemyAI;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int enemyKillCount;
    public Text score;
    public float difficultyNumber;
    // Use this for initialization
    void Start () {

        InvokeRepeating("Spawn", spawnTime, spawnTime);


	}
	
	// Update is called once per frame
	void Spawn () {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

    void ScoreCheck()
    {
        score.text = "Enemies killed: " + enemyKillCount;
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
}
