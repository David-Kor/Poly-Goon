using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{


    GameObject pOption;          //옵션 화면 판넬
    GameObject pScreen;          //초기 화면 판넬
    GameObject Change_name;        //이름변경 화면 판넬
    GameObject Check_Change;       //이름변경 확인 화면 판넬
    GameObject Error_Change;       //변경할 이름이 공백인 경우 출력 판넬
    GameObject selectPolygoon;   //도형 선택 판넬   
    static public GameObject UI_Text;
    GameObject Game_Result;
    GameObject Rank;

    public static GameObject Hexagon_Game;
    public static GameObject Pentagon_Game;
    public static GameObject Circle_Game;



    InputField 이름입력;     //사용자에게 변경할 이름을 받는 InputField

    static public Text 사용자이름;         //사용자 이름을 받아올 변수
    Text 입력받는text;       //InputField의 값을 저장할 변수
    
    void Awake ()
    {
        pScreen = transform.Find("Canvas/pScreen").gameObject;
        pOption = transform.Find("Canvas/pOption").gameObject;
        Change_name = transform.Find("Canvas/Change_name").gameObject;
        Check_Change = transform.Find("Canvas/Check_Change").gameObject;
        Error_Change = transform.Find("Canvas/Error_Change").gameObject;
        selectPolygoon = transform.Find("Canvas/SelectPolygoon").gameObject;
        UI_Text = transform.Find("Canvas/UI_Text").gameObject;
        Game_Result = transform.Find("Canvas/Game_Result").gameObject;
        Rank = transform.Find("Canvas/Rank").gameObject;

        이름입력 = transform.Find("Canvas/Change_name/InputField").GetComponent<InputField>();
        사용자이름 = transform.GetChild(0).GetChild(1).GetChild(3).GetChild(1).GetComponent<Text>();
        입력받는text = transform.Find("Canvas/Check_Change/Text").GetComponent<Text>();

        Hexagon_Game = GameObject.Find("Hexagon_Game").gameObject;
        Pentagon_Game = GameObject.Find("Pentagon_Game").gameObject;
        Circle_Game = GameObject.Find("Circle_Game").gameObject;

        pScreen.SetActive(true);
        pOption.SetActive(false);
        Change_name.SetActive(false);
        Check_Change.SetActive(false);
        selectPolygoon.SetActive(false);
        UI_Text.SetActive(false);
        Game_Result.SetActive(false);
        Rank.GetComponent<RankSystem>().Init();
        Rank.SetActive(false);

        Hexagon_Game.SetActive(false);
        Pentagon_Game.SetActive(false);
        Circle_Game.SetActive(false);

        //레지스트리에 저장된 사용자 이름 호출
        사용자이름.text = PlayerPrefs.GetString("Playername", 사용자이름.text);
        
    }
    public void GameStart()
    {
        if (selectPolygoon.activeSelf == false)
        {
            selectPolygoon.SetActive(true);
            pScreen.SetActive(false);
        }
    }          //게임 시작
    public void Option()
    {
        if (pOption.activeSelf == false)
        {
            pOption.SetActive(true);
            pScreen.SetActive(false);
        }
    }             //옵션 설정
    public void Quit()
    {
        Application.Quit();
    }               //프로그램 종료 
    public void Sumbit()
    {
        if (pOption.activeSelf == true)
        {
            pOption.SetActive(false);
            pScreen.SetActive(true);
        }
    }             //옵션창 끄기(확인)
    public void Change_Name()
    {
        if(Change_name.activeSelf == false)
        {
            Change_name.SetActive(true);
        }
    }        //이름 변경하는 판넬 호출
    public void fCheck_Change()
    {
        if(이름입력.text == "")
        {
            Error_Change.SetActive(true);
        }
        else
        {
            if (Check_Change.activeSelf == false)
            {
                Check_Change.SetActive(true);
                입력받는text.text = 이름입력.text;
            }
            else
            {
                Check_Change.SetActive(false);
            }
        }
    }      //해당 이름으로 변경할 것인지 확인
    public void yes()
    {
        Check_Change.SetActive(false);
        Change_name.SetActive(false);
        사용자이름.text = 이름입력.text;
        PlayerPrefs.SetString("Playername", 사용자이름.text);
        사용자이름.text = PlayerPrefs.GetString("Playername", 사용자이름.text);
    }                //사용자 이름 변경 확정
    public void no()
    {
        Check_Change.SetActive(false);
        Change_name.SetActive(false);
    }                 //사용자 이름 변경 취소
    public void error_Sumbit()          //이름 변경 실패시 작동
    {
        if (Error_Change.activeSelf == true)
            Error_Change.active = !Error_Change.active;
        Error_Change.SetActive(Error_Change.active);
    }           
    public void Active_Rank()           //랭킹창 활성화
    {
        Rank.SetActive(true);
        pOption.SetActive(false);
    }          
    public void Unactive_Rank()         //랭킹창 비활성화
    {
        Rank.SetActive(false);
        pScreen.SetActive(true);
    }
    public void Click_Hexagon()         //헥사곤 게임 시작
    {
        if (selectPolygoon.activeSelf == true)
        {
            selectPolygoon.SetActive(false);
            Hexagon_Game.SetActive(true);
            UI_Text.SetActive(true);
            UI_Text.GetComponentInChildren<BestScore>().Init_BScore(0);
            gameObject.GetComponentInChildren<Music>().ControlMusic(1);
        }
    }
    public void Click_Pentagon()        //펜타곤 게임 시작
    {
        if (selectPolygoon.activeSelf == true)
        {
            selectPolygoon.SetActive(false);
            Pentagon_Game.SetActive(true);
            UI_Text.SetActive(true);
            UI_Text.GetComponentInChildren<BestScore>().Init_BScore(1);
            gameObject.GetComponentInChildren<Music>().ControlMusic(2);
        }
    }
    public void Click_Circle()          //서클 게임 시작
    {
        if (selectPolygoon.activeSelf == true)
        {
            selectPolygoon.SetActive(false);
            Circle_Game.SetActive(true);
            UI_Text.SetActive(true);
            UI_Text.GetComponentInChildren<BestScore>().Init_BScore(2);
            gameObject.GetComponentInChildren<Music>().ControlMusic(3);
        } 
    }
    public void LoadHexagon()           //헥사곤 랭킹 불러오기
    {
        for (int i = 0; i < 10; i++)
        {
            RankSystem.hexagonPlayerName[i].text = PlayerPrefs.GetString("Hexagon Best Player " + i, RankSystem.hexagonPlayerName[i].text);
            RankSystem.hexagonBestScore[i].text = PlayerPrefs.GetString("Hexagon Best Score " + i, RankSystem.hexagonBestScore[i].text);
        }
    }
    public void LoadPentagon()          //펜타곤 랭킹 불러오기
    {
        for (int i = 0; i < 10; i++)
        {
            RankSystem.pentagonPlayerName[i].text = PlayerPrefs.GetString("Pentagon Best Player " + i, RankSystem.pentagonPlayerName[i].text);
            RankSystem.pentagonBestScore[i].text = PlayerPrefs.GetString("Pentagon Best Score " + i, RankSystem.pentagonBestScore[i].text);
        }
    }
    public void LoadCircle()            //원 랭킹 불러오기
    {
        for (int i = 0; i < 10; i++)
        {
            RankSystem.circlePlayerName[i].text = PlayerPrefs.GetString("Circle Best Player " + i, RankSystem.circlePlayerName[i].text);
            RankSystem.circleBestScore[i].text = PlayerPrefs.GetString("Circle Best Score " + i, RankSystem.circleBestScore[i].text);
        }
    }
}
