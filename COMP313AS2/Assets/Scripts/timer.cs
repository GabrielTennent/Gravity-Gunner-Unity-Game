using UnityEngine;
using System.Collections;

public class Timer
{
    protected float timeTracker; //tracking current time passed
    protected float length; //in seconds

    // Use this for initialization
    public Timer(float length)
    {
        this.length = length; //in seconds
        this.timeTracker = 0;
    }

    public void resetTimer()
    {
        this.timeTracker = 0;
    }

    public float getLength
    {
        get { return this.length; }
        set { this.length = value; }
    }

    // Update is called once per frame
    void Update()
    {
        this.timeTracker += Time.deltaTime;
    }

    public bool timeComplete()
    {
        if (timeTracker < length) return false;
        else return true;
    }
}



public class boostTimer : Timer
{
    protected float boostCoolDown;
    protected float boostCDTracker;

    public boostTimer(float boostLength, float boostCD) : base(boostLength)
    {
        length = boostLength;
        timeTracker = 0;
        this.boostCoolDown = boostCD;
        this.boostCDTracker = 0;
    }

    public bool checkBoostCoolDown()
    {
        if (this.boostCDTracker < this.boostCoolDown) return false;
        else return true;
    }

    public void updateBoost(float time)
    {
        this.boostCDTracker += time;
    }

}

