using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2D collision class used to implement box collisions in the game for different objects

public class collision : MonoBehaviour
{


    private Collider2D[] hits; //List of all the collisions occuring on the player
    private ContactFilter2D contact; //Contact filter - lets you filter what collisions are wanted

    // Start is called before the first frame update
    void Start()
    {
        this.contact = new ContactFilter2D();
        this.hits = new Collider2D[50];
    }

    // Update is called once per frame
    void Update()
    {
        //Initiating the empty array of values collided with
        this.hits = new Collider2D[50];
    }

    //void CollisionCheck() //Polygon collision check
    //{
    //    float collisions = Physics2D.OverlapCollider(playerCollider, contact, hits);

    //    if (collisions != 0) //If there is a recorded collision
    //    {
    //        foreach (Collider2D hit in hits) //For all of the collisions recorded
    //        {
    //            if (hit == playerCollider) continue; //Checking to see if colliding itself

    //            ColliderDistance2D colliderDistance = hit.Distance(playerCollider); //Distance from the collision object to player object

    //            if (colliderDistance.isOverlapped) //checks to see if the distance is overlapped
    //            {
    //                transform.Translate(colliderDistance.pointA - colliderDistance.pointB); //Fix the position of the player to account for the collision
    //            }

    //        }
    //    }
    //}
}
