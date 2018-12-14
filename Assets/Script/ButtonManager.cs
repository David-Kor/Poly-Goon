using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    RankSystem rankSystem = new RankSystem();

    private bool pOption_flag;
    private bool pScreen_flag;
    private bool namePanel_flag;
    private bool checkPanel_flag;
    private bool errorChange_flag;
    static public bool selectPolygoon_flag;
    static public bool Hexagon_flag;
    static public bool Pentagon_flag;
    static public bool Circle_flag;
    static public bool Game_Result_flag;
    private bool UI_Text_flag;

    public GameObject pOption;          //옵션 화면 판넬
    public GameObject pScreen;          //초기 화면 판넬
    public GameObject namePanel;        //이름변경 화면 판넬
    public GameObject checkPanel;       //이름변경 확인 화면 판넬
    public GameObject errorPanel;       //변경할 이름이 공백인 경우 출력 판넬
    public GameObject selectPolygoon;   //도형 선택 판넬   
    public GameObject Hexagon_Game;
    public GameObject Penagon_Game;
    public GameObject Circle_Game;
    public GameObject UI_Text;
    public GameObject Game_Result;
   


    public InputField 이름입력;     //사용자에게 변경할 이름을 받는 InputField

    public Text 사용자이름;         //사용자 이름을 받아올 변수
    public Text 입력받는text;       //InputField의 값을 저장할 변수

    void Start ()
    {
        pScreen_flag = true;
        pOption_flag = false;
        namePanel_flag = false;
        checkPanel_flag = false;
        errorChange_flag = false;
        selectPolygoon_flag = false;
        UI_Text_flag = false;
        Game_Result_flag = false;

        Hexagon_flag = false;
        Pentagon_flag = false;
        Circle_flag = false;

        pScreen.SetActive(pScreen_flag);
        pOption.SetActive(pOption_flag);
        namePanel.SetActive(namePanel_flag);
        checkPanel.SetActive(checkPanel_flag);
        selectPolygoon.SetActive(selectPolygoon_flag);
        UI_Text.SetActive(UI_Text_flag);
        Game_Result.SetActive(Game_Result_flag);
        //레지스트리에 저장된 사용자 이름 호출
        사용자이름.text = PlayerPrefs.GetString("Playername", 사용자이름.text);
    }
	
	// Update is called once per frame
	void Update ()
    {
                
    }

    public void GameStart()
    {
        if (selectPolygoon_flag == false)
        {
            selectPolygoon_flag = !selectPolygoon_flag;
            pScreen_flag = !pScreen_flag;

            selectPolygoon.SetActive(selectPolygoon_flag);
            pScreen.SetActive(pScreen_flag);
        }
    }          //게임 시작
    public void Option()
    {
        if (pOption_flag == false)
        {
            pOption_flag = !pOption_flag;
            pScreen_flag = !pScreen_flag;

        }
        pOption.SetActive(pOption_flag);
        pScreen.SetActive(pScreen_flag);
    }             //옵션 설정
    public void Quit()
    {
        Application.Quit();
    }               //프로그램 종료 
    public void Sumbit()
    {
        if (pOption_flag == true)
        {
            pOption_flag = !pOption_flag;
            pScreen_flag = !pScreen_flag;
        }
        pOption.SetActive(pOption_flag);
        pScreen.SetActive(pScreen_flag);
    }             //옵션창 끄기(확인)
    public void Change_Name()
    {
        if(namePanel_flag == false)
        {
            namePanel_flag = !namePanel_flag;
        }
        namePanel.SetActive(namePanel_flag);
    }        //이름 변경하는 판넬 호출
    public void Check_Change()
    {
        if(이름입력.text == "")
        {
            errorChange_flag = !errorChange_flag;
            errorPanel.SetActive(errorChange_flag);
        }
        else
        {

            if (checkPanel_flag == false)
            {
                checkPanel_flag = !checkPanel_flag;
                checkPanel.SetActive(checkPanel_flag);

                입력받는text.text = 이름입력.text;
            }
            else
            {
                checkPanel.SetActive(checkPanel_flag);
            }
        }
    }       //해당 이름으로 변경할 것인지 확인
    public void yes()
    {
        사용자이름.text = 입력받는text.text;
        checkPanel_flag = !checkPanel_flag;
        namePanel_flag = !namePanel_flag;

        checkPanel.SetActive(checkPanel_flag);
        namePanel.SetActive(namePanel_flag);
        PlayerPrefs.SetString("Playername", 사용자이름.text);
    }                //사용자 이름 변경 확정
    public void no()
    {
        checkPanel_flag = !checkPanel_flag;
        namePanel_flag = !namePanel_flag;

        checkPanel.SetActive(checkPanel_flag);
        namePanel.SetActive(namePanel_flag);
    }                 //사용자 이름 변경 취소
    public void error_Sumbit()
    {
        if(errorChange_flag == true)
            errorChange_flag = !errorChange_flag;
        errorPanel.SetActive(errorChange_flag);
    }
    public void Click_Hexagon()
    {
        if (selectPolygoon_flag == true)
        {
            selectPolygoon_flag = !selectPolygoon_flag;
            Hexagon_flag = !Hexagon_flag;
            UI_Text_flag = !UI_Text_flag;

            UI_Text.SetActive(UI_Text_flag);
            selectPolygoon.SetActive(selectPolygoon_flag);
            Hexagon_Game.SetActive(Hexagon_flag);
        }
    }
    public void Click_Pentagon()
    {
        if (selectPolygoon_flag == true)
        {
            selectPolygoon_flag = !selectPolygoon_flag;
            Pentagon_flag = !Pentagon_flag;
            UI_Text_flag = !UI_Text_flag;

            selectPolygoon.SetActive(selectPolygoon_flag);
            Penagon_Game.SetActive(Pentagon_flag);
            UI_Text.SetActive(UI_Text_flag);
        }
    }
    public void Click_Circle()
    {
        if (selectPolygoon_flag == true)
        {
            selectPolygoon_flag = !selectPolygoon_flag;
            Circle_flag = !Circle_flag;
            UI_Text_flag = !UI_Text_flag;

            selectPolygoon.SetActive(selectPolygoon_flag);
            Circle_Game.SetActive(Circle_flag);
            UI_Text.SetActive(UI_Text_flag);
        } 
    }
    public void GameOver()
    {
            Game_Result_flag = !Game_Result_flag;
            Game_Result.SetActive(Game_Result_flag);
    }

    void rHexagon()
    {
        rankSystem.LoadHexagon();
    }
}
