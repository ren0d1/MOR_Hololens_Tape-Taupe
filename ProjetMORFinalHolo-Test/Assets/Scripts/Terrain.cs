using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

    private int rotateLevel = 0;
    private static Terrain instance;

    public Terrain()
    {
        instance = this;
    }
    public void setRotate(int rotateLevel)
    {
        this.rotateLevel = rotateLevel;
    }

    public int getRotate()
    {
        return rotateLevel;
    }

    public static Terrain getInstance()
    {
        return instance;
    }
	
	// Update is called once per frame
	void Update () {
        float scaledSpeed = rotateLevel * Time.deltaTime;
        transform.Rotate(Vector3.up * scaledSpeed, Space.Self);
    }
}
