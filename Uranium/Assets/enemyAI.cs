using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {
    public float speed;
    public Transform target;
    public float switchTimer;
    public string moveType;
    
    // PeteyWoufes, 21/11/17

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // switchTimer += Time.deltaTime; // will use for flight pattern switching eventually
        MoveTo();
        // Replacing MoveDirect() and MoveLeft() for simplicity reasons
    }

    void DeathCheck ()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void MoveTo()
    {
        if (moveType == "Right")
        {
            float step = -speed * Time.deltaTime;
            transform.Translate(step, 0, 0);
        }

        if (moveType == "Left")
        {
            float step = speed * Time.deltaTime;
            transform.Translate(step, 0, 0);
        }

        if (moveType == "Up")
        {
            float step = speed * Time.deltaTime;
            transform.Translate(0, step, 0);
        }

        if (moveType == "Down")
        {
            float step = -speed * Time.deltaTime;
            transform.Translate(0, step, 0);
        }

        if (moveType == "Direct")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    
}
