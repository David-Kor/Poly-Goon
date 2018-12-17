using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore: MonoBehaviour {

    GameObject Hexagon_Game;
    GameObject Pentagon_Game;
    GameObject Circle_Game;

    private int bestScore = 0;
    private bool isInit = false;

    private Text Best_Score_Count;     //최고점수를 출력할 텍스트

    public void Init_BScore(short shape)
    {
        switch (shape)
        {
            case 0:
                Hexagon_Game = GameObject.Find("Hexagon_Game").gameObject;
                break;
            case 1:
                Pentagon_Game = GameObject.Find("Pentagon_Game").gameObject;
                break;
            case 2:
                Circle_Game = GameObject.Find("Circle_Game").gameObject;
                break;
        }
        Best_Score_Count = transform.GetChild(0).GetComponent<Text>();
        isInit = true;
    }
    public void Exit_BScore()
    {
        isInit = false;
        Hexagon_Game = null;
        Pentagon_Game = null;
        Circle_Game = null;
    }
    void Update()
    {
        if (isInit)
        {
            Check();
        }
    }
    // Update is called once per frame
    void Check()
    {
        if(Hexagon_Game != null)
        {
            RankSystem.LoadHexagon();
            bestScore = int.Parse(RankSystem.hexagonBestScore[0].text);

            if (int.Parse(RankSystem.hexagonBestScore[0].text) > Score.score)
            {
                Best_Score_Count.text = bestScore.ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = bestScore.ToString();
            }
        }
        else if(Pentagon_Game != null)
        {
            bestScore = int.Parse(RankSystem.pentagonBestScore[0].text);

            if (int.Parse(RankSystem.pentagonBestScore[0].text) > Score.score)
            {
                Best_Score_Count.text = bestScore.ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = bestScore.ToString();
            }
        }
        else if (Circle_Game != null) 
        {
            bestScore = int.Parse(RankSystem.circleBestScore[0].text);

            if (int.Parse(RankSystem.circleBestScore[0].text) > Score.score)
            {
                Best_Score_Count.text = bestScore.ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = bestScore.ToString();
            }
        }
    }
}
