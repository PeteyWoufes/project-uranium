using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
    private Animator anim;
    public Animation anim2;
    public bool isAliveAnim;
    public float deathTimer;
    public pauseMenu pauseMenu;
    public bulletShooter bs;
    public GameObject deathUI;
    public int playerHealthCurrent;
    public int playerHealthMax;
    public int targetFPS = 60;
    public Transform shield;
    public Sprite[] laserBeamSprites;
    public Image laserBeamImage;

    // TEMP
    public Text playerHealth;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        anim2 = gameObject.GetComponent<Animation>();
        anim.SetBool("isAlive", true);
        isAliveAnim = true;
        deathTimer = 0f;
        deathUI.SetActive(false);
        Application.targetFrameRate = targetFPS;
        playerHealthCurrent = playerHealthMax;
    }
	
	void Update () {
        HealthCheck();
        laserBeamImage.sprite = laserBeamSprites[bs.laserAmmo / 10];
        QualitySettings.vSyncCount = 0;
        bs.isAlive = isAliveAnim;
        if (Application.targetFrameRate != targetFPS)
        {
            Application.targetFrameRate = targetFPS;
        }
        if (isAliveAnim == false)
        {
            anim.SetBool("isAlive", false);
            Camera.main.GetComponent<CameraControl>().Shake(150.5f, 150, 0.75f);
        }
        if (isAliveAnim == false)
        {
            deathTimer += Time.deltaTime;
            
        }
        if (deathTimer >= 2.2f)
        {
            Time.timeScale = 0;
            deathUI.SetActive(true);
            
        }

        if (Input.GetKey(KeyCode.Alpha1)) {
            targetFPS = 30;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            targetFPS = 45;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            targetFPS = 60;
        }
        //if (Input.GetKey(KeyCode.A))
        //{
        //    shield.Rotate(0, 0.2f * Time.deltaTime, -1f);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    shield.Rotate(0, 0.2f * Time.deltaTime, 1f);
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealthCurrent -= 2;
            Destroy(other);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealthCurrent -= 3;
        }
    }

    void HealthCheck()
    {
        playerHealth.text = "Population: " + playerHealthCurrent;
        if (playerHealthCurrent <= 1)
        {
            isAliveAnim = false;
        }
    }
}
