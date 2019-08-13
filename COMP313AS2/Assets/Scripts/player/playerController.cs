using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    //player fields
    private playerHealth health;
    public float movementSpeed = 5;
    public float jumpForce = 1000;

    //Movementy keys
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode gravityFlip;
    public KeyCode shoot;

    //Facing direction check
    private bool horizontalFlip; //bool - keeps track of whether the player has changed from initial direction or not\
    private bool gravityCheck;

    private Rigidbody2D body; //represents rigid body compenent on player
    private SpriteRenderer rend; //renderer - lets you access renderer compenent for the player in the script

    //Shooting fields
    public Transform firePoint;
    public GameObject bullet;

    //Reload times
    public float maxAmmo = 3;
    public float ammoAmount;
    public Timer reloadTimer;
    public float reloadTime = 2;
    private bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        this.reloadTimer = new Timer(reloadTime);
        this.reloading = false;
        this.ammoAmount = maxAmmo;

        //Initalizing fields for movement
        this.body = GetComponent<Rigidbody2D>();
        this.rend = GetComponent<SpriteRenderer>();
        this.health = GetComponent<playerHealth>();

        //Computing gravity switches
        this.horizontalFlip = false;
        this.gravityCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTimer.timeComplete())
        {
            ammoAmount = maxAmmo;
            reloadTimer.resetTimer();
            reloading = false;
        } else if (reloading)
        {
            reloadTimer.Update(Time.deltaTime);
        }

        if(!reloading) CheckShot();
    }

    private void FixedUpdate()
    {
        horizontalMovement();
        JumpMovement();
        GravityMovement();
    }

    void horizontalMovement()
    {
        //Horizontal Movement
        Vector2 updatedHorizontalVel = new Vector2(0, body.velocity.y);
        //Horizontal movement - acceleration  = (velocity - initial velocity) / deltatime

        if (Input.GetKey(right)) //player input = right
        {
            updatedHorizontalVel = new Vector2(movementSpeed, this.body.velocity.y);
            if (this.horizontalFlip)
            {
                transform.Rotate(0, 180, 0);
                horizontalFlip = false;
            }
        } else if (Input.GetKey(left))
        {
            updatedHorizontalVel = new Vector2(-movementSpeed, this.body.velocity.y);
            if (!this.horizontalFlip)
            {
                transform.Rotate(0, 180, 0);
                horizontalFlip = true;
            }
        }

        body.velocity = updatedHorizontalVel;
    }

    void JumpMovement() {
        //Player Jumping
        if (Input.GetKeyDown(jump))
        {
            body.AddForce(new Vector2(this.body.velocity.x, jumpForce *= -1));
        }
    }

    void GravityMovement() { 
        //Vertical Gravity movement
        if (Input.GetKeyDown(gravityFlip))
        {
            body.gravityScale *= -1;
            transform.Rotate(0, 180, 180);
            if (gravityCheck) gravityCheck = false;
            else gravityCheck = true;
        }

    }

    void CheckShot()
    {
        if (ammoAmount > 0)
        {
            if (Input.GetKeyDown(shoot))
            {
                ammoAmount -= 1;
                GameObject bulletRef;
                bulletRef = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletRef.GetComponent<Bullet>().shooter = this.gameObject;
            }
        } else if (ammoAmount == 0)
        {
            this.reloading = true;
        }
    }


    public void takeDamage()
	{
       health.takeDamage(1);
       if (health.curHealth == 0)
       {
          endGame();
       }
	}

    void endGame()
    {
        SceneManager.LoadScene(0);
    }

    bool IsApprox(float a, float b, float tolerence)
    {
        return Mathf.Abs(a - b) < tolerence;
    }
}
