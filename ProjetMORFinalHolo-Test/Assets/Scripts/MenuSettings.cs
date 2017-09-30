using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettings : MonoBehaviour {
    public GameObject panelMenu;
    public GameObject panelSettings;
    public GameObject panelScore;
    public Transform scoresList;

    public void SelectPanelSettings()
    {
        panelMenu.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void ExitPanelSettings()
    {
        panelSettings.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void SelectPanelScore()
    {
        panelMenu.SetActive(false);
        panelScore.SetActive(true);
        Score.getInstance().showScore(scoresList);
    }

    public void ExitPanelScore()
    {
        panelScore.SetActive(false);
        panelMenu.SetActive(true);
    }
}
