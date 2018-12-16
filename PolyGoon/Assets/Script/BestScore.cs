using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore: MonoBehaviour {

    GameObject Hexagon_Game;
    GameObject Pentagon_Game;
    GameObject Circle_Game;

    int bestScore = 0;

    private Text Best_Score_Count;     //최고점수를 출력할 텍스트

	void Awake () {
        Hexagon_Game = GameObject.Find("Hexagon_Game").gameObject;
        Pentagon_Game = GameObject.Find("Pentagon_Game").gameObject;
        Circle_Game = GameObject.Find("Circle_Game").gameObject;

        Best_Score_Count = transform.GetChild(0).GetComponent<Text>();
	}
    void Update()
    {
        Check();    
    }
    // Update is called once per frame
    void Check()
    {
        if(Hexagon_Game.active == true)
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
        else if(Pentagon_Game.active == true)
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
        else if (Circle_Game.active == true) 
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
