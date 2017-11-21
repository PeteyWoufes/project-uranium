using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {
    public float speed;
    public Transform target;
    public float switchTimer;
    public float formationTimer;
    public string moveType;
    public string moveFormation;
    private bool goingUp;
    
    // PeteyWoufes, 21/11/17

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // switchTimer += Time.deltaTime; // will use for flight pattern switching eventually
        MoveTo();
        // Replacing MoveDirect() and MoveLeft() for simplicity reasons
        Formation();
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
        if (moveType == "Left")
        {
            float step = -speed * Time.deltaTime;
            transform.Translate(step, 0, 0);
        }

        if (moveType == "Right")
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

    void Formation()
    {
        if (moveFormation == "Zigzag")
        {
            formationTimer += Time.deltaTime;
            if (formationTimer >= 0.75f)
            {
                goingUp = !goingUp;
                formationTimer = 0;
            }
            if (goingUp == true)
            {
                moveType = "Up";
            }
            else
            {
                moveType = "Direct";
            }

        }

        
    }

    
}
