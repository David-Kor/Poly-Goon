using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore: MonoBehaviour {

    int bestScore = 0;
    int start = 0;

    private Text Best_Score_Count;     //최고점수를 출력할 텍스트

	void Start () {
        Best_Score_Count = GameObject.Find("Canvas").transform.Find("UI_Text").transform.Find("Best_Score").transform.Find("Best_Score_Count").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Check();
	}
    void Check()
    {
        if(ButtonManager.Hexagon_flag == true)
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
        else if(ButtonManager.Pentagon_flag == true)
        {
            if (RankSystem.hexagonBestScore[0] > Score.score)
            {
                Best_Score_Count.text = RankSystem.hexagonBestScore.ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = RankSystem.hexagonBestScore[0].ToString();
            }
        }
        else
        {
            if (RankSystem.hexagonBestScore[0] > Score.score)
            {
                Best_Score_Count.text = RankSystem.hexagonBestScore.ToString();
            }
            else
            {
                bestScore = Score.score;
                Best_Score_Count.text = RankSystem.hexagonBestScore[0].ToString();
            }
        }
    }
}
