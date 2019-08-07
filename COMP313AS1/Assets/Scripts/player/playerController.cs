using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement fields
    [SerializeField] private float maxPlayerSpeed = 50.0f; //Float - player speed
    [SerializeField] private float timeToMaxSpeed = 2f; //float - time taken for player to reach max speed
    private float accelRatePerSec; //stores maxPlayerSpeed/timeToMaxSpeed - so that you know how much to accelerate each second
    private float rightVelocity; //stores current right velocity of the player
    private float leftVelocity; //stores current left velocity of the player

    [SerializeField] private Transform groundCheck; //a position marking where the players feet are

    private BoxCollider2D topCollider; //box collider repsenting the top half of the player collision;
    private CircleCollider2D bottomCollider; //circle collider presenting the bottom half of the player;
    private Rigidbody2D body; //represents rigid body compenent on player

    private SpriteRenderer rend; //renderer - lets you access renderer compenent for the player in the script
    private bool horizontalFlip; //bool - keeps track of whether the player has changed from initial direction or not
    private bool gravityFlip; //bool - keeps track of what direction the gravity is effecting the player
    private const float speedDirChange = 0.25f;

    private float horizontal; //float - each update holds the input of the player for horizontal movement


    // Start is called before the first frame update
    void Start()
    {
        //Initalizing fields for movement
        this.body = GetComponent<Rigidbody2D>();
        this.rend = GetComponent<SpriteRenderer>();

        //Computing gravity switches
        this.horizontalFlip = false;
        this.gravityFlip = false;

        //Computing player inputs and horizontal movement
        this.horizontal = Input.GetAxisRaw("Horizontal");
        accelRatePerSec = maxPlayerSpeed / timeToMaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Computing player inputs and horizontal movement
        this.horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Movement();
        CheckShot();
    }

    void Movement()
    {
        Vector2 updatedVel = new Vector2(0, body.velocity.y);
        //Horizontal movement - acceleration  = (velocity - initial velocity) / deltatime
        if (horizontal != 0){ //player input
            if (horizontal > 0) //player input = right
            {
                rightVelocity += accelRatePerSec * Time.deltaTime;
                rightVelocity = Mathf.Min(rightVelocity, maxPlayerSpeed);
                if (leftVelocity > 0) //player velocity = left
                {
                    leftVelocity = 0; //reset velocity as player has countered the momentum
                    rightVelocity = 0;
                }
                else
                {
                    updatedVel = new Vector2((horizontal * rightVelocity), body.velocity.y);

                    if (horizontalFlip && rightVelocity > speedDirChange) //applys appropriate rendering to character
                    {
                        this.rend.flipX = false;
                        horizontalFlip = false;
                    }
                }
            }
            else //player input = left
            {
                leftVelocity += accelRatePerSec * Time.deltaTime;
                leftVelocity = Mathf.Min(leftVelocity, maxPlayerSpeed);

                if (rightVelocity > 0) //player velocity = right
                {
                    leftVelocity = 0; //reset velocity as player has countered the momentum
                    rightVelocity = 0; 
                }
                else
                {
                    updatedVel = new Vector2((horizontal * leftVelocity), body.velocity.y);

                    if (!horizontalFlip && leftVelocity > speedDirChange) //applys appropriate rendering to character
                    {
                        this.rend.flipX = true;
                        horizontalFlip = true;
                    }
                }
            }
        }
        else //no player input
        {
            if (rightVelocity > 0) //if currently moving right
            {
                rightVelocity -= accelRatePerSec * Time.deltaTime;
                rightVelocity = Mathf.Max(rightVelocity, 0);
                updatedVel = new Vector2(rightVelocity, body.velocity.y); //updated with slowing down

            }
            else if (leftVelocity > 0) //if currently moving left
            {
                leftVelocity -= accelRatePerSec * Time.deltaTime;
                leftVelocity = Mathf.Max(leftVelocity, 0);
                updatedVel = new Vector2(leftVelocity * -1, body.velocity.y); //updated with slowing down
            }
        }

        body.velocity = updatedVel;

        //Vertical Gravity movement
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (gravityFlip) gravityFlip = false;
            else gravityFlip = true;
            body.gravityScale *= -1;
        }

        //Gravity rendering changes on sprite renderer
        if (gravityFlip)
        { 
            this.rend.flipY = true;
        } else 
        {
            this.rend.flipY = false;
        }


    }

    void CheckShot()
    {
        if(IsApprox(body.velocity.y, 0, 0.1f)
            && IsApprox(body.velocity.x, 0, 0.1f))
        {
            rend.material.SetColor("_Color", Color.green);
        } else
        {
            rend.material.SetColor("_Color", Color.red);
        }
    }

    bool IsApprox(float a, float b, float tolerence)
    {
        return Mathf.Abs(a - b) < tolerence;
    }
}
