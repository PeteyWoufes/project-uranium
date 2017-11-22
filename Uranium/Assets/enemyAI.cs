using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {

    public Transform target;
    public float speed;
    public float switchTimer;
    public float formationTimer;
    public string moveType;
    public string moveFormation;
    private bool goingUp;
    
    // PeteyWoufes, 22/11/17

	void Update () {
        MoveCheck();
        FormationCheck();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void MoveCheck()
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

    void FormationCheck()
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
