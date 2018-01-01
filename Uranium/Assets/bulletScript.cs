using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {
    public float lifeTimer;
    public float lifeLimit;

	void Update ()
    {
        lifeTimerCheck();
	}

    void lifeTimerCheck()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeLimit)
        {
            Destroy(gameObject);
        }
    }
}
