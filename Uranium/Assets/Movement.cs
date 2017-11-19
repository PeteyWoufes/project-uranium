using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public Rigidbody2D p2D;
    public float movex;
    public float movey;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        InputCheck();
        p2D.velocity = p2D.velocity + new Vector2(movex * speed, movey * speed);
        //transform.Translate(movex, movey, Time.deltaTime);
    }

    void InputCheck ()
    {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
    }

 
}
