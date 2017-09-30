using System.Collections;
using UnityEngine;

public class move : MonoBehaviour {

    public KeyCode upKey;
    public KeyCode downKey;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float scaledSpeed = 1f * Time.deltaTime;
        if (Input.GetKey(upKey))
	    {
            GetComponent<Transform>().Translate(Vector3.up * scaledSpeed, Space.Self);
        }
        else if (Input.GetKey(downKey))
	    {
            GetComponent<Transform>().Translate(Vector3.down * scaledSpeed, Space.Self);
        }

    }
}
