using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {
    private Animator anim;
    public Animation anim2;
    public bool isAliveAnim;
    public float deathTimer;
    public pauseMenu pauseMenu;
    public bulletShooter bs;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
        anim2 = gameObject.GetComponent<Animation>();
        anim.SetBool("isAlive", true);
        isAliveAnim = true;
        deathTimer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        bs.isAlive = isAliveAnim;
        if (isAliveAnim == false)
        {
            anim.SetBool("isAlive", false);
        }
        if (isAliveAnim == false)
        {
            deathTimer += Time.deltaTime;
            
        }
        if (deathTimer == 2.2f)
        {
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isAliveAnim = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isAliveAnim = false;
        }
    }
}
