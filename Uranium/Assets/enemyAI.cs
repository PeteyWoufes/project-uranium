using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyAI : MonoBehaviour {

    public EnemyManager enemyManager;
    public Transform target;
    public float speed;
    public float switchTimer;
    public float formationTimer;
    public string moveType;
    public string moveFormation;
    public string enemyType;
    private bool goingUp;
    public Animator anim;
    public bool laserEnabled;


    // PeteyWoufes, 22/11/17

    void Update () {
        MoveCheck();
        FormationCheck();
        EnemyTypeCheck();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            enemyManager.enemyKillCount += 1;
            enemyManager.difficultyNumber += 1;
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

            if (formationTimer >= 0.15f)
            {
                float step = speed * Time.deltaTime;
                
                goingUp = !goingUp;
                formationTimer = 0;
            }

            if (goingUp == true)
            {
                transform.Translate(1, 1, 0);
            }

            else
            {
                moveType = "Direct";
            }

        }

        if (moveFormation == "Orbit")
        {
            transform.RotateAround(Vector2.zero, -Vector3.forward, 90 * Time.deltaTime);
        }

    }

    void EnemyTypeCheck()
    {
        if (enemyType == "Rotatatron")
        {
            transform.Rotate(Vector3.back);
        }

        if (enemyType == "laserCannon")
        {
            transform.right = target.position - transform.position;
            if ((transform.position.x - target.position.x) <= 6.5f)
            {
                laserEnabled = true;
            }

            if ((transform.position.x - target.position.x) <= 3.92f)
            {
                speed = 0;
            }

            //if (Input.GetKey(KeyCode.J))
            //{
                
               // laserEnabled = true;
          //  }
            else
            {
               
                laserEnabled = false;
            }

            if (laserEnabled == true)
            {
                anim.SetBool("laserEnabled", true);
            }

            else
            {
                anim.SetBool("laserEnabled", false);
            }
        }
    }

    

    
}
