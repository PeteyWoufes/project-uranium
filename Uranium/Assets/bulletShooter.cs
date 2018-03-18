using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShooter : MonoBehaviour {
    public GameObject laser;
    public Rigidbody2D bullet;
    public Transform barrel;
    public Vector2 curScreenPoint;
    public float bulSpeed;
    public bool isAlive;
    public bool laserOn;
    public int laserAmmo;
    public float readyTimer;
    public AudioSource audioSource;
    public GameObject laserBeam;



    void Start () {
        isAlive = true;
        laserAmmo = 100;
	}
	
	void Update () {
        BulletCheck();
        LaserCheck();
        Debug.Log(laserAmmo);
        if (Time.timeScale == 0)
        {
            laserBeam = gameObject.transform.Find("laserBeam").gameObject;
            AudioSource aS = laserBeam.GetComponent<AudioSource>();
            aS.volume = 0;
        }
        else if (Time.timeScale == 1)
        {
            laserBeam = gameObject.transform.Find("laserBeam").gameObject;
            AudioSource aS = laserBeam.GetComponent<AudioSource>();
            aS.volume = 0.448f;
        }

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
                instance.AddForce(fwd * (bulSpeed));
                audioSource.Play();
            }


            if (Input.GetButton("Fire2"))
            {
                if (laserAmmo != 0)
                {
                    laser.SetActive(true);
                    laserAmmo -= 1;
                    laserOn = true;
                }
            }
            else
            {
                laser.SetActive(false);

            }
            if (laserAmmo == 0)
            {
                laser.SetActive(false);
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
    private void LaserCheck()
    {
        if (laserAmmo <= 0)
            laserAmmo = 0;
        if (laserAmmo >= 100)
            laserAmmo = 100;

    


            
    }
}
