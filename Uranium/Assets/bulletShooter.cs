using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShooter : MonoBehaviour {
    public Rigidbody2D bullet;
    public Transform barrel;
    public Vector2 curScreenPoint;
    public float bulSpeed;
    public bool isAlive;
    public playerScript playerScript;
    
	// Use this for initialization
	void Start () {
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        BulletCheck();
        
	}
    
    void BulletCheck ()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                curScreenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Rigidbody2D instance = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation) as Rigidbody2D;
                Vector2 fwd = curScreenPoint -= new Vector2(0, 0);
                instance.AddForce(fwd * bulSpeed);
            }

        }
       
    }

    private void OnColliderEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isAlive = false;
            
            
        }

        else if (other.CompareTag("Laser"))
        {
            isAlive = false;
            
        }
    }
}
