using UnityEngine;

/*****  임의의 패턴 큐를 생성하여 장애물을 활성화 시키는 클래스  *****/
public class ObstacleCreator : MonoBehaviour
{
    //전체 패턴 큐(prefab) 리스트
    public GameObject[] patternList;
    
    //현재 패턴 큐
    private ObstaclePattern pattern;
    //패턴 큐의 마지막 장애물
    public GameObject lastObstacle;
    //장애물 생성 시작 여부
    private bool doCreatPattern;
    //패턴 큐 리스트에서 랜덤으로 고른 패턴 큐의 인덱스
    private int index;

    void Start()
    {
        lastObstacle = null;
        doCreatPattern = true;
        pattern = null;
    }

    void Update()
    {
        //임의의 패턴을 선택하여 장애물 생성을 시작
        if (doCreatPattern)
        {
            doCreatPattern = false;
            index = Random.Range(0, patternList.Length);
            pattern = Instantiate(patternList[index]).GetComponent<ObstaclePattern>();
            //패턴 큐 상태 초기화
            pattern.InitPattern();

            int count = pattern.GetCountQueue();
            for (int i = 0; i < count; i++)
            {
                //각 장애물들을 순서대로 활성화
                //for문이 다 돌면 lastObstacle는 마지막으로 활성화된 장애물을 가리키게 됨
                lastObstacle = pattern.ActivateDequeueObstacle();
                if (lastObstacle == null) { break; }
            }

            //모든 장애물이 활성화 되면 생성된 패턴 큐 인스턴스를 삭제
            if (pattern != null) { Destroy(pattern.gameObject); }
        }

        //마지막 장애물의 크기가 9이하가 되면 다시 새로운 패턴을 생성
        if (lastObstacle != null)
        {
            if (lastObstacle.transform.localScale.x <= 9f)
            {
                doCreatPattern = true;
                lastObstacle = null;
            }
        }
        //게임 재시작등의 이유로 lastObstacle이 null이 되면 다시 새로운 패턴 생성
        else
        {
            doCreatPattern = true;
        }
    }
}
