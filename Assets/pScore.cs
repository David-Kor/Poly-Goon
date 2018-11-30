using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pScore : MonoBehaviour {
    static public int score = 0;
    public Text pScoretext;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Timer.GameOver)
            return;

        string Score = score.ToString();
        pScoretext.text = Score;
	}
}
