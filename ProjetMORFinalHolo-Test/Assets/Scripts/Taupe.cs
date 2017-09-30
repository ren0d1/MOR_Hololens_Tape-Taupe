using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taupe : MonoBehaviour {

    private bool casque = false;
    private int points = 0;
    private int counterRotation = 1;
    private Taupe instance;
    private bool kill = false;
    private Animation anim;
    private float tempo = 1f;

    public Taupe()
    {
        instance = this;
    }

    public void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
    }

    public Taupe getInstance()
    {
        return instance;
    }

    public void setCasque(bool casque)
    {
        this.casque = casque;
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
        if(casque)
        {
            casque = false;
            //Debug.Log("taupe avait un casque.");
            this.gameObject.transform.Find("TaupeLow1").Find("Tape_Taupe:D3").GetComponent<Renderer>().enabled = false;
            tempo = 0f;
        }else{
            if(!kill && tempo >= 1)
            {
                Score.getInstance().setScore(points);
                Animation anim = this.GetComponent<Animation>();
                anim["Take 001"].speed = -1.0f;
                anim["Take 001"].time = anim["Take 001"].length;
                anim.Play();
                kill = true;
            }
        }
    }

    public bool getKill()
    {
        return kill;
    }

    // Update is called once per frame
    void Update () {
        float scaledSpeed = counterRotation * Time.deltaTime;
        transform.Rotate(Vector3.down * scaledSpeed, Space.Self);
        tempo += Time.deltaTime;
        if (!anim.isPlaying && kill)
        {
            Destroy(this.gameObject);
        }
    }
}
