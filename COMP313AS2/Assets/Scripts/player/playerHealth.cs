using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 5;

    private void Start()
    {
        this.curHealth = this.maxHealth;
        Debug.Log(curHealth);
    }

    // Update is called once per frame
    public void takeDamage(int dmg)
    {
        this.curHealth -= dmg;
        Debug.Log(curHealth);
    }
}
