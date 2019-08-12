using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    private GameObject player; //Player game object
    private Vector3 offSet; //Stores difference in player and camera position

    // Start is called before the first frame update
    void Start()
    {
        //this.player = GameObject.Find("player"); //Returns game object named Player
        //this.offSet = transform.position - player.transform.position; //Finds different for offset variable
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + offSet; //Accounts for difference in positions keeping the camera locked
    }
}
