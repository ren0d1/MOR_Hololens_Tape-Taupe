using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour {

    private int points = 0;
    private int counterRotation = 1;
    private Chat instance;
    private bool kill = false;
    private Animation anim;

    public Chat()
    {
        instance = this;
    }

    public void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
    }

    public Chat getInstance()
    {
        return instance;
    }

    public void setPoints(int points)
    {
        this.points = points;
    }

    public void setRotate(int counterRotation)
    {
        this.counterRotation = counterRotation;
    }

    public void getHit()
    {
        if (!kill)
        {
            Score.getInstance().setScore(-points);
            Animation anim = this.GetComponent<Animation>();
            anim["Take 001"].speed = -1.0f;
            anim["Take 001"].time = anim["Take 001"].length;
            anim.Play();
            kill = true;
        }
    }

    public int notHit()
    {
        return points;
    }

    public bool getKill()
    {
        return kill;
    }

    // Update is called once per frame
    void Update()
    {
        float scaledSpeed = counterRotation * Time.deltaTime;
        transform.Rotate(Vector3.down * scaledSpeed, Space.Self);
        if (!anim.isPlaying && kill)
        {
            Destroy(this.gameObject);
        }
    }
}
