using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore: MonoBehaviour {

    GameObject Hexagon_Game;
    GameObject Pentagon_Game;
    GameObject Circle_Game;

    int bestScore = 0;
    int start = 0;

    private Text Best_Score_Count;     //최고점수를 출력할 텍스트

	void Start () {
        Hexagon_Game = GameObject.Find("Hexagon_Game").gameObject;
        //Pentagon_Game = GameObject.Find("Pentagon_Game").gameObject;
        //Circle_Game = GameObject.Find("Circle_Game").gameObject;

        Best_Score_Count = GameObject.Find("Canvas/UI_Text/Best_Score/Best_Score_Count").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Check();
	}
    void Check()
    {
        if(Hexagon_Game.active == true)
        {
            if (RankSystem.hexagonBestScore[0] > Score.score)
            {
                Best_Score_Count.text = RankSystem.hexagonBestScore[0].ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = bestScore.ToString();
            }
        }
        /*else if(Pentagon_Game.active == true)
        {
            if (RankSystem.pentagonBestScore[0] > Score.score)
            {
                Best_Score_Count.text = RankSystem.pentagonBestScore.ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = RankSystem.pentagonBestScore[0].ToString();
            }
        }
        else
        {
            if (RankSystem.hexagonBestScore[0] > Score.score)
            {
                Best_Score_Count.text = RankSystem.circleBestScore.ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = RankSystem.circleBestScore[0].ToString();
            }
        }*/
    }
}
