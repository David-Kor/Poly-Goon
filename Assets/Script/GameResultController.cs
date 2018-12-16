using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultController : MonoBehaviour {

    GameObject pScreen;
    GameObject UI_Text;
    GameObject Game_Result;

    GameObject Hexagon_Game;
    GameObject Pentagon_Game;
    GameObject Circle_Game;

    private Text UI_Time;
    private Text UI_Score;
    private Text Game_Result_Time;
    private Text Game_Result_Score;


    // Use this for initialization
	void Start ()
    {
        pScreen = transform.parent.transform.Find("pScreen").gameObject;
        UI_Text = GameObject.Find("Canvas/UI_Text").gameObject;
        Game_Result = GameObject.Find("Canvas/Game_Result").gameObject;

        UI_Time = GameObject.Find("Canvas/UI_Text/Time/Time_Count").GetComponent<Text>();
        UI_Score = GameObject.Find("Canvas/UI_Text/Score/Score_Count").GetComponent<Text>();
        Game_Result_Time = GameObject.Find("Canvas/Game_Result/Playtime/PlaytimeCount").GetComponent<Text>();
        Game_Result_Score = GameObject.Find("Canvas/Game_Result/PlayScore/PlayScoreCount").GetComponent<Text>();

        Hexagon_Game = ButtonManager.Hexagon_Game;
        Pentagon_Game = ButtonManager.Pentagon_Game;
        Circle_Game = ButtonManager.Circle_Game;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Game_Result_Time.text = UI_Time.text;
        Game_Result_Score.text = UI_Score.text;

        if (Input.anyKeyDown)
        {
            RankSystem.CheckBestScore(Game_Result_Score.text);
            pScreen.SetActive(true);
            gameObject.SetActive(false);

            if (Hexagon_Game.active == true)
            {
                Hexagon_Game.SetActive(false);
                Hexagon_Game.GetComponentInChildren<PlayerInputManager>().Reset();
            }
            else if (Pentagon_Game.active == true)
            {
                Pentagon_Game.SetActive(false);
                Pentagon_Game.GetComponentInChildren<PlayerInputManager>().Reset();
            }
            else if (Circle_Game.active == true)
            {
                Circle_Game.SetActive(false);
                Circle_Game.GetComponentInChildren<PlayerInputManager>().Reset();
            }

            UI_Text.SetActive(false);

            Timer.t = 0;
            Obstacle.ClearObstacles();
            Score.score = 0;

        }
	}
}
