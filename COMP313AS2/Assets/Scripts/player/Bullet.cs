using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigid;
    //public float bounce = 10000;
    public GameObject shooter;

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * speed;
    }

    void Update()
    {

    }

    void destoryBullet()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player1")
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.takeDamage();
        } else if (collision.gameObject.name == "player2")
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.takeDamage();
        }


        if (collision.gameObject.name != "player1" && collision.gameObject.name != "player2" 
            && collision.gameObject.name != "Walls" && collision.gameObject.name != "Floor"
            && collision.gameObject.name != "Roof")
        {
            Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer meteorRend = collision.gameObject.GetComponent<SpriteRenderer>();
            Meteor meteor = collision.gameObject.GetComponent<Meteor>();
            SpriteRenderer shooterRend = shooter.GetComponent<SpriteRenderer>();

            Vector2 positionDiff = body.transform.position - rigid.transform.position;
            if(rigid.velocity.x < 0)
            {
                body.velocity = new Vector2((rigid.velocity.x * positionDiff.normalized.x) * -1, (rigid.velocity.x * positionDiff.normalized.y) *-1);             
                //add mass
                //body.velocity = new Vector2(body.velocity.x * -body.mass, body.velocity.y * -body.mass);
            } else
            {
                body.velocity = new Vector2(rigid.velocity.x * positionDiff.normalized.x, rigid.velocity.x * positionDiff.normalized.y);
            }


            if(shooter.name == "player1")
            {
                meteor.p1Controlled = true;
                meteor.p2Controlled = false;
                meteor.neutral = false;
            } else if(shooter.name == "player2")
            {
                meteor.p1Controlled = false;
                meteor.p2Controlled = true;
                meteor.neutral = false;
            }

            meteorRend.material.SetColor("_Color", shooterRend.color);
            
        }

        Destroy(this.gameObject);
    }
}
