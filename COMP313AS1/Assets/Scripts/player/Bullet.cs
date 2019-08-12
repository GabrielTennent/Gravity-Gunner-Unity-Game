using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 150f;
    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player1")
        {
            player1Controller p1Cont = collision.gameObject.GetComponent<player1Controller>();
            p1Cont.takeDamage();
        }
        if (collision.gameObject.name == "player2")
        {
            player2Controller p2Cont = collision.gameObject.GetComponent<player2Controller>();
            p2Cont.takeDamage();
        }
        Destroy(this.gameObject);
    }
}
