using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    static public int score = 0;

    private Text Score_Count;                 //score를 Text에 저장

    void Start ()
    {
        Score_Count = GameObject.Find("Canvas").transform.Find("UI_Text").transform.Find("Score").transform.Find("Score_Count").GetComponent<Text>();
    }
	

	void Update ()
    {
        if (Timer.GameOver)
            return;
        
        Score_Count.text = score.ToString();
	}
}
