using UnityEngine;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{
    public static int i = 0;

    public static Text[] hexagonBestScore = new Text[10];
    public static Text[] hexagonPlayerName = new Text[10];

    public static Text[] pentagonBestScore = new Text[10];
    public static Text[] pentagonPlayerName = new Text[10];

    public static Text[] circleBestScore = new Text[10];
    public static Text[] circlePlayerName = new Text[10];

    public void Init()
    {
        Transform nameText = transform.GetChild(0).GetChild(1);
        Transform scoreText = transform.GetChild(0).GetChild(2);

        for (i = 0; i < 10; i++)
        {
             hexagonPlayerName[i] = nameText.GetChild(i).GetComponent<Text>();
             hexagonBestScore[i] = scoreText.GetChild(i).GetComponent<Text>();

             pentagonPlayerName[i] = nameText.GetChild(i).GetComponent<Text>();
             pentagonBestScore[i] = scoreText.GetChild(i).GetComponent<Text>();

             circlePlayerName[i] = nameText.GetChild(i).GetComponent<Text>();
             circleBestScore[i] = scoreText.GetChild(i).GetComponent<Text>();
        }
    }
    
    static void SaveHexagon()
    {
        if (ButtonManager.Hexagon_Game.activeSelf == false) { return; }

        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("Hexagon Best Player " + i, hexagonPlayerName[i].text);
            PlayerPrefs.SetString("Hexagon Best Score " + i, hexagonBestScore[i].text);
        }
    }
    static void SavePentagon()
    {
        if (ButtonManager.Pentagon_Game.activeSelf == false) { return; }

        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("Pentagon Best Player " + i, pentagonPlayerName[i].text);
            PlayerPrefs.SetString("Pentagon Best Score " + i, pentagonBestScore[i].text);
        }
    }
    static void SaveCircle()
    {
        if (ButtonManager.Circle_Game.activeSelf == false) { return; }

        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("Circle Best Player " + i, circlePlayerName[i].text);
            PlayerPrefs.SetString("Circle Best Score " + i, circleBestScore[i].text);
        }
    }

    public void CheckBestScore(string n)
    {
        if (ButtonManager.Hexagon_Game.activeSelf == true)
        {
            transform.parent.parent.GetComponentInChildren<ButtonManager>().LoadHexagon();
            int j = 0;
            for (int i = 0; i < 10; i++)
            {

                if (int.Parse(n) >= int.Parse(hexagonBestScore[i].text))
                {
                    for (j = 8; j > i; j--)
                    {
                        hexagonBestScore[i + 1].text = hexagonBestScore[i].text;
                        hexagonPlayerName[i + 1].text = hexagonPlayerName[i].text;
                    }
                    hexagonBestScore[i].text = n;
                    hexagonPlayerName[j].text = ButtonManager.사용자이름.text;
                    break;
                }
            }
            SaveHexagon();
            transform.parent.parent.GetComponentInChildren<ButtonManager>().LoadHexagon();
        }
        else if (ButtonManager.Pentagon_Game.activeSelf == true)
        {
            transform.parent.parent.GetComponentInChildren<ButtonManager>().LoadPentagon();
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                if (int.Parse(n) >= int.Parse(pentagonBestScore[i].text))
                {
                    for (j = 8; j > i; j--)
                    {
                        pentagonBestScore[i + 1].text = pentagonBestScore[i].text;
                        pentagonPlayerName[i + 1].text = pentagonPlayerName[i].text;
                    }
                    pentagonBestScore[i].text = n;
                    pentagonPlayerName[j].text = ButtonManager.사용자이름.text;
                    break;
                }
            }
            SavePentagon();
            transform.parent.parent.GetComponentInChildren<ButtonManager>().LoadPentagon();
        }
        else if (ButtonManager.Circle_Game.activeSelf == true)
        {
            transform.parent.parent.GetComponentInChildren<ButtonManager>().LoadCircle();
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                if (int.Parse(n) >= int.Parse(circleBestScore[i].text))
                {
                    for (j = 8; j > i; j--)
                    {
                        circleBestScore[i + 1].text = circleBestScore[i].text;
                        circlePlayerName[i + 1].text = circlePlayerName[i].text;
                    }
                    circleBestScore[i].text = n;
                    circlePlayerName[j].text = ButtonManager.사용자이름.text;
                    break;
                }
            }
            SaveCircle();
            transform.parent.parent.GetComponentInChildren<ButtonManager>().LoadCircle();
        }
    }

}