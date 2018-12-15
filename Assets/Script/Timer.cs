using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class Timer : MonoBehaviour {
    public static bool GameOver = false;                    //게임오버 구현되면 사용할 부분

    private Text Timertext;

    private float startTime;
    private float countTime = 0.5F;                          //최초로 점수가 시작되는 시간(단위: 초)
    private float addTime = 0.5F;                            //최초로 점수가 추가된 이후로 몇 초 뒤에 점수를 추가할지 설정.

    void Start ()
    {
        startTime = Time.time;                             //시간 초기화
        Timertext = GameObject.Find("Canvas/UI_Text/Time/Time_Count").GetComponent<Text>();

    }

    void Update()
    {
        float t = Time.time - startTime;

        string Minutes = ((int)t / 60).ToString("d2");
        string Seconds = ((int)t % 60).ToString("d2");
        string Miliseconds = (((t % 60) % 1) * 100).ToString("f0");

        if (GameOver)                                       //게임오버 구현되면 사용할 부분
            return;

        Watch(Minutes, Seconds, Miliseconds);               //게임 진행시간 출력

        if (countTime < t)
        {
            Score.score += 100;
            countTime = addTime + t;
        }
    }

    public void Finish()
    {
        GameOver = true;
        Timertext.color = Color.red;
    }                                 //게임오버 구현되면 사용할 부분
    public void Watch(string Minutes, string Seconds, string Miliseconds)
    {
        Timertext.text = Minutes + ":" + Seconds + ":" + Miliseconds;
    }
}
