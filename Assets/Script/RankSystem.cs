using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{

    static public int i = 0;

    public static int[] hexagonBestScore = new int[10];
    public static int[] pentagonBestScore = new int[10];
    public static int[] circleBestScore = new int[10];
    public static Text[] hexagonPlayerName = new Text[10];
    public static Text[] pentagonPlayerName = new Text[10];
    public static Text[] circlePlayerName = new Text[10];

    void Start () {
        for(i = 0; i<10; i++)
        {
            hexagonPlayerName[i] = GameObject.Find("Canvas").transform.Find("Rank").transform.Find("기본Text").transform.Find("사용자 이름").transform.Find("플레이어 이름 (" + (i+1) + ")").GetComponent<Text>();
            pentagonPlayerName[i] = GameObject.Find("Canvas").transform.Find("Rank").transform.Find("기본Text").transform.Find("사용자 이름").transform.Find("플레이어 이름 (" + (i+1) + ")").GetComponent<Text>();
            circlePlayerName[i] = GameObject.Find("Canvas").transform.Find("Rank").transform.Find("기본Text").transform.Find("사용자 이름").transform.Find("플레이어 이름 (" + (i+1) + ")").GetComponent<Text>();
        }
        LoadHexagon();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadHexagon()
    {
        for (int i = 0; i < 10; i++)
        {
            hexagonPlayerName[i].text = PlayerPrefs.GetString("Hexagon Best Player " + i, hexagonPlayerName[i].ToString());
            hexagonBestScore[i] = PlayerPrefs.GetInt("Hexagon Best Score " + i, hexagonBestScore[i]);
        }
    }
    void LoadPentagon()
    {
        for (int i = 0; i < 10; i++)
        {
            pentagonPlayerName[i].text = PlayerPrefs.GetString("Pentagon Best Player " + i, pentagonPlayerName[i].ToString());
            pentagonBestScore[i] = PlayerPrefs.GetInt("Pentagon Best Score " + i, pentagonBestScore[i]);
        }
    }
    void LoadCircle()
    {
        for (int i = 0; i < 10; i++)
        {
            circlePlayerName[i].text = PlayerPrefs.GetString("Circle Best Player " + i, circlePlayerName[i].ToString());
            circleBestScore[i] = PlayerPrefs.GetInt("Circle Best Score " + i, circleBestScore[i]);
        }
    }
    static void SaveHexagon(int i)
    {
        PlayerPrefs.SetString("Hexagon Best Player " + i, hexagonPlayerName[i].text);
        PlayerPrefs.SetInt("Hexagon Best Score " + i, hexagonBestScore[i]);
    }
    static void SavePentagon(int i)
    {
        PlayerPrefs.SetString("Pentagon Best Player " + i, pentagonPlayerName[i].text);
        PlayerPrefs.SetInt("Pentagon Best Score " + i, pentagonBestScore[i]);
    }
    static void SaveCircle(int i)
    {
        PlayerPrefs.SetString("Circle Best Player " + i, circlePlayerName[i].text);
        PlayerPrefs.SetInt("Circle Best Score " + i, circleBestScore[i]);
    }
    public static void CheckBestScore(int n)
    {
        if(ButtonManager.Hexagon_flag == true)
        {
            n = 0;
            for (int i = 0; i < 10; i++)
            {
                if(Score.score >= hexagonBestScore[i])
                {
                    for (i = 8; i >= n; i--)
                    {
                        hexagonBestScore[i + 1] = hexagonBestScore[i];
                        hexagonPlayerName[i + 1] = hexagonPlayerName[i];
                    }
                    hexagonBestScore[n] = Score.score;
                   // hexagonPlayerName[i] = 
                    break;
                }
                else
                {
                    n++;
                }
            }
            
            
        }
    }
}
