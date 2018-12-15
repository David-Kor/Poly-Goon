using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultController : MonoBehaviour {

    GameObject pScreen;
    GameObject Hexagon_Game;
    GameObject Game_Result;

    private Text Game_Result_Time;
    private Text Game_Result_Bestscore;


    // Use this for initialization
	void Start ()
    {
        pScreen = transform.parent.transform.Find("pScreen").gameObject;
        
        //Game_Result_Time = transform.Find("Canvas/Game_Result/Playtime/PlaytimeCount").GetComponent<Text>();
        //Game_Result_Bestscore = transform.Find("Canvas/Game_Result/PlayScore/PlayScorecount").GetComponent<Text>();

        Hexagon_Game = GameObject.Find("Hexagon_Game");


    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.anyKeyDown)
        {
            pScreen.SetActive(true);
            gameObject.SetActive(false);
            Hexagon_Game.SetActive(false);
            RankSystem.CheckBestScore();
        }
	}
}
