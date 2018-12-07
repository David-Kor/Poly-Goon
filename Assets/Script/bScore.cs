using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bScore : MonoBehaviour {

    int bestScore = 0;

    public Text bScoretext;     //최고점수를 출력할 텍스트

	void Start () {
        LoadBestScore();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bestScore > pScore.score)
        {
            bScoretext.text = bestScore.ToString();
        }
        else
        {
            bestScore = pScore.score;
            bScoretext.text = bestScore.ToString();
            SaveBestScore();
        }
	}

    void SaveBestScore()
    {
        PlayerPrefs.SetInt("Best Score", bestScore);        //레지스트리에 Best Score라는 이름으로 저장
    }
    void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", bestScore);    //레지스트리에서 최고점수 불러오기
    }
}
