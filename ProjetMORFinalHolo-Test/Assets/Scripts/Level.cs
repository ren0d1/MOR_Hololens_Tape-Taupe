using UnityEngine.UI;
using UnityEngine;

public class Level : MonoBehaviour {

    private int level = 1;
    private static Level instance;
    public Text scoreDisplay;
    public GameObject menu;

    public Level()
    {
        instance = this;
    }

    public void setLevel(GameObject scroll)
    {
        level = (int) (scroll.GetComponent<Scrollbar>().value * 100);
        scoreDisplay.text = scoreDisplay.text.Substring(0, 6) + " " + level;
        menu.GetComponent<StartGame>().setLevel();
    }

    public int getLevel()
    {
        return level;
    }

    public static Level getInstance()
    {
        return instance;
    }
}
