﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultController : MonoBehaviour
{

    GameObject pScreen;
    GameObject UI_Text;

    GameObject Hexagon_Game;
    GameObject Pentagon_Game;
    GameObject Circle_Game;

    private bool doSave = false;
    private bool check = false;

    private Text UI_Time;
    private Text UI_Score;
    private Text Game_Result_Time;
    private Text Game_Result_Score;

    private float activeTime;
    private float waitTime;

    // Use this for initialization
    void init()
    {
        doSave = true;
        pScreen = transform.parent.Find("pScreen").gameObject;
        UI_Text = transform.parent.GetChild(6).gameObject;

        UI_Time = UI_Text.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        UI_Score = UI_Text.transform.GetChild(1).GetChild(0).GetComponent<Text>();

        //Canvas/Game_Result/Playtime/PlaytimeCount
        Game_Result_Time = transform.GetChild(1).GetChild(1).GetComponent<Text>();
        //Canvas/Game_Result/PlayScore/PlayScoreCount
        Game_Result_Score = transform.GetChild(2).GetChild(1).GetComponent<Text>();

        Hexagon_Game = ButtonManager.Hexagon_Game;
        Pentagon_Game = ButtonManager.Pentagon_Game;
        Circle_Game = ButtonManager.Circle_Game;

        activeTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        waitTime = Time.realtimeSinceStartup - activeTime;
        if(waitTime > 1)
        {
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.R))
            {
                gameObject.SetActive(false);
                gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);

                if (Hexagon_Game.activeSelf == true)
                {
                    Hexagon_Game.SetActive(false);
                    Hexagon_Game.GetComponentInChildren<PlayerInputManager>().Reset();
                }
                else if (Pentagon_Game.activeSelf == true)
                {
                    Pentagon_Game.SetActive(false);
                    Pentagon_Game.GetComponentInChildren<PlayerInputManager>().Reset();
                }
                else if (Circle_Game.activeSelf == true)
                {
                    Circle_Game.SetActive(false);
                    Circle_Game.GetComponentInChildren<PlayerInputManager>().Reset();
                }
                UI_Text.SetActive(false);
                UI_Text.GetComponentInChildren<BestScore>().Exit_BScore();

                Timer.t = 0;
                Obstacle.ClearObstacles();
                Score.score = 0;
                doSave = false;

                gameObject.transform.parent.parent.GetComponentInChildren<Music>().ControlMusic(0);
                check = false;
            }
        }
    }

    // Update is called once per frame
    public void SaveRecord()
    {
        init();
        Game_Result_Time.text = UI_Time.text;
        Game_Result_Score.text = UI_Score.text;
        transform.parent.GetChild(7).GetComponentInChildren<RankSystem>().CheckBestScore(Game_Result_Score.text);
    }
}
