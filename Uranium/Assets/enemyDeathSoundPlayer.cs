using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeathSoundPlayer : MonoBehaviour {
    public float deathTimer;
    public int deathClock;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        deathTimer += Time.deltaTime;
        DeathCheck();
	}

    void DeathCheck()
    {
        if (deathTimer > deathClock)
        {
            Destroy(gameObject);
        }
    }
}
