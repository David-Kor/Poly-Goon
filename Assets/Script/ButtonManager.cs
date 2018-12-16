using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    RankSystem rankSystem = new RankSystem();

    private bool pOption_flag;
    private bool pScreen_flag;
    private bool Change_name_flag;
    private bool Check_Change_flag;
    private bool errorChange_flag;
    static public bool selectPolygoon_flag;
    static public bool Hexagon_flag;
    static public bool Pentagon_flag;
    static public bool Circle_flag;
    static public bool Game_Result_flag;
    private bool UI_Text_flag;

    GameObject pOption;          //옵션 화면 판넬
    GameObject pScreen;          //초기 화면 판넬
    GameObject Change_name;        //이름변경 화면 판넬
    GameObject Check_Change;       //이름변경 확인 화면 판넬
    GameObject Error_Change;       //변경할 이름이 공백인 경우 출력 판넬
    GameObject selectPolygoon;   //도형 선택 판넬   
    static public GameObject UI_Text;
    GameObject Game_Result;
    GameObject Rank;

    static public GameObject Hexagon_Game;
    static public GameObject Pentagon_Game;
    static public GameObject Circle_Game;



    InputField 이름입력;     //사용자에게 변경할 이름을 받는 InputField

    static public Text 사용자이름;         //사용자 이름을 받아올 변수
    Text 입력받는text;       //InputField의 값을 저장할 변수

    void Start ()
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
        사용자이름 = transform.Find("Canvas/pOption/사용자이름").GetComponent<Text>();
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
        Rank.SetActive(false);

        Hexagon_Game.SetActive(false);
        Pentagon_Game.SetActive(false);
        Circle_Game.SetActive(false);

        //레지스트리에 저장된 사용자 이름 호출
        사용자이름.text = PlayerPrefs.GetString("Playername", 사용자이름.text);

        Debug.Log(Hexagon_Game.name);
    }
	// Update is called once per frame
	void Update ()
    {
                
    }

    public void GameStart()
    {
        if (selectPolygoon.active == false)
        {
            selectPolygoon.SetActive(true);
            pScreen.SetActive(false);
        }
    }          //게임 시작
    public void Option()
    {
        if (pOption.active == false)
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
        if (pOption.active == true)
        {
            pOption.SetActive(false);
            pScreen.SetActive(true);
        }
    }             //옵션창 끄기(확인)
    public void Change_Name()
    {
        if(Change_name_flag == false)
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
            if (Check_Change.active == false)
            {
                Check_Change.SetActive(true);
                입력받는text.text = 이름입력.text;
            }
            else
            {
                Check_Change.SetActive(false);
            }
        }
    }       //해당 이름으로 변경할 것인지 확인
    public void yes()
    {
        Check_Change.SetActive(false);
        Change_name.SetActive(false);
        사용자이름.text = 이름입력.text;
        PlayerPrefs.SetString("Playername", 사용자이름.text);
    }                //사용자 이름 변경 확정
    public void no()
    {
        Check_Change.SetActive(false);
        Change_name.SetActive(false);
    }                 //사용자 이름 변경 취소
    public void error_Sumbit()
    {
        if (Error_Change.active == true)
            Error_Change.active = !Error_Change.active;
        Error_Change.SetActive(Error_Change.active);
    }
    public void Active_Rank()
    {
        Rank.SetActive(true);
        pOption.SetActive(false);
    }
    public void Unactive_Rank()
    {
        Rank.SetActive(false);
        pScreen.SetActive(true);
    }
    public void Click_Hexagon()
    {
        if (selectPolygoon.activeSelf == true)
        {
            selectPolygoon.SetActive(false);
            Hexagon_Game.SetActive(true);
            UI_Text.SetActive(true);
        }
    }
    public void Click_Pentagon()
    {
        if (selectPolygoon.activeSelf == true)
        {
            selectPolygoon.SetActive(false);
            Pentagon_Game.SetActive(true);
            UI_Text.SetActive(true);
        }
    }
    public void Click_Circle()
    {
        if (selectPolygoon.activeSelf == true)
        {
            selectPolygoon.SetActive(false);
            Circle_Game.SetActive(true);
            UI_Text.SetActive(true);
        } 
    }
    public void GameOver()
    {
        Game_Result.SetActive(true);
    }
}
