using UnityEngine.UI;
using UnityEngine;

using System.IO;
using System.Collections.Generic;
using System.Text;
using System;

public class Score : MonoBehaviour
{

    private int score = 0;
    public Text scoreDisplay;
    public Font arial;
    private static Score instance;
    private string saveFile;

    public Score()
    {
        instance = this;
    }

    public static Score getInstance()
    {
        if(instance.saveFile == null)
        {
            instance.saveFile = Application.persistentDataPath + "/scores.save";
        }
        return instance;
    }

    public void setScore(int score)
    {
        this.score += score;
    }

    public void resetScore()
    {
        score = 0;
    }

    public void writeScore()
    {
        FileStream stream = File.Open(saveFile, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding(65001));
        string temp = score.ToString() + " (lvl " + Terrain.getInstance().getRotate() + ")";

        try
        {
            writer.WriteLine(temp);
        }
        catch
        {
            Debug.Log("exception trouvée; score non inscrit");
        }
        finally
        {
            writer.Flush();
            writer.Dispose();
            sortScores();
        }
    }

    private void sortScores()
    {
        List<string> scoresComplets = new List<string>();

        FileStream stream = File.Open(saveFile, FileMode.OpenOrCreate, FileAccess.Read);

        using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(65001)))
        {
            string temp;

            while ((temp = reader.ReadLine()) != null)
            {
                scoresComplets.Add(temp);
            }

            reader.Dispose();
        }

        for (int i = scoresComplets.Count - 2; i >= 0; i--)
        {
            for (int j = 0; j <= i; j++)
            {
                if (Int32.Parse(scoresComplets[j + 1].Substring(0, scoresComplets[j + 1].IndexOf(' '))) > Int32.Parse(scoresComplets[j].Substring(0, scoresComplets[j].IndexOf(' '))))
                {
                    string temp = scoresComplets[j];
                    scoresComplets[j] = scoresComplets[j + 1];
                    scoresComplets[j + 1] = temp;
                }else if (Int32.Parse(scoresComplets[j + 1].Substring(0, scoresComplets[j + 1].IndexOf(' '))) == Int32.Parse(scoresComplets[j].Substring(0, scoresComplets[j].IndexOf(' ')))){
                    if (Int32.Parse(scoresComplets[j].Substring(scoresComplets[j].IndexOf("lvl") + 4, scoresComplets[j].Substring(scoresComplets[j].IndexOf("lvl") + 4).IndexOf(')'))) < Int32.Parse(scoresComplets[j + 1].Substring(scoresComplets[j + 1].IndexOf("lvl") + 4, scoresComplets[j + 1].Substring(scoresComplets[j + 1].IndexOf("lvl") + 4).IndexOf(')'))))
                    {
                        string temp = scoresComplets[j];
                        scoresComplets[j] = scoresComplets[j + 1];
                        scoresComplets[j + 1] = temp;
                    }
                }
            }
        }

        if(scoresComplets.Count > 10)
        {
            scoresComplets.RemoveRange(10, scoresComplets.Count - 10);
        }

        File.WriteAllLines(saveFile, scoresComplets.ToArray());
    }

    public void showScore(Transform scoreContainer)
    {
        FileStream stream = File.Open(saveFile, FileMode.OpenOrCreate, FileAccess.Read);

        using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(65001)))
        {
            string score;
            int i = 1;
            float rankPos = 0.45f;

            foreach(Transform temp in scoreContainer)
            {
                Destroy(temp.gameObject);
            }

            while ((score = reader.ReadLine()) != null)
            {
                GameObject textObject = new GameObject("Rank " + i);
                textObject.transform.SetParent(scoreContainer);
                textObject.transform.localPosition = new Vector3(0, rankPos, 0);
                textObject.transform.localScale = new Vector3(0.003f, 0.003f, 0);
                Text myText = textObject.AddComponent<Text>();
                myText.font = arial;
                myText.color = Color.black;
                myText.alignment = TextAnchor.MiddleCenter;
                myText.horizontalOverflow = HorizontalWrapMode.Overflow;
                myText.resizeTextForBestFit = true;
                myText.resizeTextMinSize = 10;
                myText.resizeTextMaxSize = 20;
                myText.text = "Rank: " + i + " -> " + score;
                i++;
                rankPos -= 0.1f;
            }
            reader.Dispose();
        }
    }

    private void Update()
    {
        scoreDisplay.text = score.ToString();
    }
}
