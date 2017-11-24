using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {
    public float lifeTimer;
    public float lifeLimit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifeCycle();
	}

    void lifeCycle()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeLimit)
        {
            Destroy(gameObject);
        }
    }
}
