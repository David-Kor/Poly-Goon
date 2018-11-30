using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bScore : MonoBehaviour {

    int bestScore = 0;
    public Text bScoretext;

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
        PlayerPrefs.SetInt("Best Score", bestScore);
    }
    void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", bestScore);
    }
}
