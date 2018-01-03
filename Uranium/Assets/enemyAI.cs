using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyAI : MonoBehaviour {

    public EnemyManager enemyManager;
    public Transform target;
    public float speed;
    private float distance;
    public string moveType;
    public string moveFormation;
    public string enemyType;
    public Animator anim;
    public bool laserEnabled;
    public Rigidbody2D rb2d;
    public Vector3 vector;


    // PeteyWoufes, 22/11/17

    void FixedUpdate () {
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
        if (moveFormation == "Flyby")
        {
            transform.Rotate(Vector3.forward * Time.deltaTime, 0.04f);
            rb2d.AddForce(transform.right * (Time.deltaTime * speed));
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

    private void Start()
    {
        if (moveFormation == "Flyby")
        {
            transform.right = target.position - transform.position;
        }
    }




}
