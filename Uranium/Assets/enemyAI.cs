using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {
    public float speed;
    public Transform target;
    public float switchTimer;
    public bool moveBehaviour_Direct;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switchTimer += Time.deltaTime;
        if (switchTimer == 5f)
        {
            moveBehaviour_Direct = !moveBehaviour_Direct;
            switchTimer = 0;

        }
        if (moveBehaviour_Direct == true)
            MoveDirect();

        if (moveBehaviour_Direct == false)
            MoveLeft();
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

    void MoveDirect()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    void MoveLeft()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(step, 0, 0);
    }
}
