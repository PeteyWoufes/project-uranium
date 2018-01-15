using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerOfGravity : MonoBehaviour {
    
	void Update ()
    {
        if (Time.timeScale == 1)
        {
            transform.Rotate(0, 0.2f * Time.deltaTime, 0.1f);
        }
        

    }

}
