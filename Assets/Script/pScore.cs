using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pScore : MonoBehaviour {
    static public int score = 0;

    public Text pScoretext;                 //score를 Text에 저장

    void Start () {
	}
	

	void Update ()
    {
        if (Timer.GameOver)
            return;
        
        pScoretext.text = score.ToString();
	}
}
