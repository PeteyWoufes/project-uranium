using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyAI : MonoBehaviour {

    public EnemyManager enemyManager;
    public Transform target;
    public float speed;
    public float switchTimer;
    public float formationTimer;
    private float distance;
    public string moveType;
    public string moveFormation;
    public string enemyType;
    private bool goingUp;
    public Animator anim;
    public bool laserEnabled;
    //public bool isAlive;
    public Rigidbody2D rb2d;
    public Vector3 vector;
    //float deathTimer;


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
            //isAlive = false;
            Destroy(gameObject);
        }

        if (other.CompareTag("Moon"))
        {
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

        if (moveFormation == "Flyby")
        {
            //transform.right = target.position - transform.position;
            transform.Rotate(Vector3.forward * Time.deltaTime, 0.07f);
            rb2d.AddForce(transform.up * (Time.deltaTime * 10f));
            //float x = 50f * Time.deltaTime;
            //rb2d.AddTorque(1f);




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
            distance = Vector2.Distance(transform.position, target.position);
            if (distance <= 6.5f)
            {
                laserEnabled = true;
            }


            if (distance <= 3.92f)
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

        //if (isAlive == false)
        //{ 
            //deathTimer += Time.deltaTime;
            //anim.SetBool("isAliveAnim", false);
           // if (deathTimer >= 2f)
            //{
            //    Destroy(gameObject);
           // }
        //}
    }

    private void Start()
    {
        if (moveFormation == "Flyby")
        {
            transform.up = target.position - transform.position;
        }
    }




}
