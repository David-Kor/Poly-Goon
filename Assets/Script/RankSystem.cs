using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{
    static public int i = 0;

    public static Text[] hexagonBestScore = new Text[10];
    public static Text[] hexagonPlayerName = new Text[10];

    public static Text[] pentagonBestScore = new Text[10];
    public static Text[] pentagonPlayerName = new Text[10];

    public static Text[] circleBestScore = new Text[10];
    public static Text[] circlePlayerName = new Text[10];

    static GameObject Hexagon_Game;
    static GameObject Pentagon_Game;
    static GameObject Circle_Game;

    void Start()
    {
        Hexagon_Game = GameObject.Find("Hexagon_Game").gameObject;
        Pentagon_Game = GameObject.Find("Pentagon_Game").gameObject;
        Circle_Game = GameObject.Find("Circle_Game").gameObject;

        for (i = 0; i < 10; i++)
        {
            
             hexagonPlayerName[i] = GameObject.Find("Canvas/Rank/기본Text/사용자 이름/플레이어 이름 (" + (i + 1) + ")").GetComponent<Text>();
             hexagonBestScore[i] = GameObject.Find("Canvas/Rank/기본Text/점수/점수 (" + (i + 1) + ")").GetComponent<Text>();

             pentagonPlayerName[i] = GameObject.Find("Canvas/Rank/기본Text/사용자 이름/플레이어 이름 (" + (i + 1) + ")").GetComponent<Text>();
             pentagonBestScore[i] = GameObject.Find("Canvas/Rank/기본Text/점수/점수 (" + (i + 1) + ")").GetComponent<Text>();

             circlePlayerName[i] = GameObject.Find("Canvas/Rank/기본Text/사용자 이름/플레이어 이름 (" + (i + 1) + ")").GetComponent<Text>();
             circleBestScore[i] = GameObject.Find("Canvas/Rank/기본Text/점수/점수 (" + (i + 1) + ")").GetComponent<Text>();
         
        }
        LoadHexagon();
    }
    
    void Update()
    {

    }
    static public void LoadHexagon()
    {
        for (int i = 0; i < 10; i++)
        {
            hexagonPlayerName[i].text = PlayerPrefs.GetString("Hexagon Best Player " + i, hexagonPlayerName[i].text);
            hexagonBestScore[i].text = PlayerPrefs.GetString("Hexagon Best Score " + i, hexagonBestScore[i].text);
        }
    }
    static public void LoadPentagon()
    {
        for (int i = 0; i < 10; i++)
        {
            pentagonPlayerName[i].text = PlayerPrefs.GetString("Pentagon Best Player " + i, pentagonPlayerName[i].text);
            pentagonBestScore[i].text = PlayerPrefs.GetString("Pentagon Best Score " + i, pentagonBestScore[i].text);
        }
    }
    static public void LoadCircle()
    {
        for (int i = 0; i < 10; i++)
        {
            circlePlayerName[i].text = PlayerPrefs.GetString("Circle Best Player " + i, circlePlayerName[i].text);
            circleBestScore[i].text = PlayerPrefs.GetString("Circle Best Score " + i, circleBestScore[i].text);
        }
    }

    static void SaveHexagon()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("Hexagon Best Player " + i, hexagonPlayerName[i].text);
            PlayerPrefs.SetString("Hexagon Best Score " + i, hexagonBestScore[i].text);
        }
    }
    static void SavePentagon()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("Pentagon Best Player " + i, pentagonPlayerName[i].text);
            PlayerPrefs.SetString("Pentagon Best Score " + i, pentagonBestScore[i].text);
        }
    }
    static void SaveCircle()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("Circle Best Player " + i, circlePlayerName[i].text);
            PlayerPrefs.SetString("Circle Best Score " + i, circleBestScore[i].text);
        }
    }

    static public void CheckBestScore(string n)
    {
        if (Hexagon_Game.activeSelf == true)
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {

                Debug.Log(hexagonPlayerName[i]);
                if (int.Parse(n) >= int.Parse(hexagonBestScore[i].text))
                {
                    for (j = 8; j > i; j--)
                    {
                        hexagonBestScore[i + 1].text = hexagonBestScore[i].text;
                        hexagonPlayerName[i + 1].text = hexagonPlayerName[i].text;
                        Debug.Log(j);
                    }
                    hexagonBestScore[i].text = n;
                    hexagonPlayerName[j].text = ButtonManager.사용자이름.text;
                    break;
                }
            }
            SaveHexagon();
        }
        else if (Pentagon_Game.activeSelf == true)
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {

                Debug.Log(pentagonPlayerName[i]);
                if (int.Parse(n) >= int.Parse(pentagonBestScore[i].text))
                {
                    for (j = 8; j > i; j--)
                    {
                        pentagonBestScore[i + 1].text = pentagonBestScore[i].text;
                        pentagonPlayerName[i + 1].text = pentagonPlayerName[i].text;
                        Debug.Log(j);
                    }
                    pentagonBestScore[i].text = n;
                    pentagonPlayerName[j].text = ButtonManager.사용자이름.text;
                    break;
                }
            }
            SavePentagon();
        }
        else if (Circle_Game.activeSelf == true)
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {

                Debug.Log(circlePlayerName[i]);
                if (int.Parse(n) >= int.Parse(circleBestScore[i].text))
                {
                    for (j = 8; j > i; j--)
                    {
                        circleBestScore[i + 1].text = circleBestScore[i].text;
                        circlePlayerName[i + 1].text = circlePlayerName[i].text;
                        Debug.Log(j);
                    }
                    circleBestScore[i].text = n;
                    circlePlayerName[j].text = ButtonManager.사용자이름.text;
                    break;
                }
            }
            SaveCircle();
        }
    }

}