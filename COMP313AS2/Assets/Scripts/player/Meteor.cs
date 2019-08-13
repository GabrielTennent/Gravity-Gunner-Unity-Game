using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    public bool neutral;
    public bool p1Controlled;
    public bool p2Controlled;

    // Start is called before the first frame update
    void Start()
    {
        this.neutral = true;
        this.p1Controlled = false;
        this.p2Controlled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player1" && p2Controlled)
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.takeDamage();
        }
        else if (collision.gameObject.name == "player2" && p1Controlled)
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            player.takeDamage();
        }
    }
}
