using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotate : MonoBehaviour {
    public float rotation;
	// Use this for initialization
	void Start () {

        rotation = Random.Range(-3f, 3f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0)
        {
            transform.Rotate(Vector3.forward, rotation);
        }
	}
}
