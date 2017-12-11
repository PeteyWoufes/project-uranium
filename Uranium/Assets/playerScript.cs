using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {
    Animator anim;
    public bool isAliveAnim;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isAlive", true);
        isAliveAnim = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isAliveAnim == false)
        {
            anim.SetBool("isAlive", false);
        }
	}
}
