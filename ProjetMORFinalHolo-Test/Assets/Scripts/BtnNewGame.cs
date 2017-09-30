using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNewGame : MonoBehaviour {

    public GameObject menu;
    public GameObject plane;
    public GameObject ui;

	public void startGame()
    {
        menu.SetActive(false);
        plane.SetActive(true);
        ui.SetActive(true);
    }
}
