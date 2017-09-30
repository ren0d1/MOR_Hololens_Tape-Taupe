using UnityEngine.UI;
using UnityEngine;
using System;

public class GameTimer : MonoBehaviour {

    public GameObject plane;
    public GameObject menu;
    public GameObject ui;
    public Text timerDisplay;
    private static GameTimer instance;
    private float tempsImparti;

    public void setTempsImparti(int tempsImparti)
    {
        this.tempsImparti = tempsImparti;
    }

    public GameTimer()
    {
        instance = this;
    }

    public static GameTimer getInstance()
    {
        return instance;
    }


	// Use this for initialization
	void Start () {
        tempsImparti = 60.0f;
        timerDisplay.text = "Time : " + tempsImparti.ToString() + "s";
    }

    private void Update()
    {
        if(tempsImparti > 0)
        {
            tempsImparti -= Time.deltaTime;
            timerDisplay.text = "Time : " + (Convert.ToInt32(tempsImparti)).ToString() + "s";
        }else{          
            plane.SetActive(false);
            ui.SetActive(false);
            menu.SetActive(true);
            tempsImparti = 60.0f;
        }
    }

    private void OnDisable()
    {
        Score.getInstance().writeScore();
        Score.getInstance().resetScore();
    }
}
