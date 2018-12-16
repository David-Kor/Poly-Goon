using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    static public int score = 0;

    private Text Score_Count;                 //score를 Text에 저장

    void Start ()
    {
        Score_Count = transform.GetChild(0).GetComponent<Text>();
    }
	

	void Update ()
    {
        if (Timer.GameOver)
            return;
        
        Score_Count.text = score.ToString();
	}
}
