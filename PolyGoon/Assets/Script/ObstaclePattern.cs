using System.Collections.Generic;
using UnityEngine;

/*****  장애물들의 패턴을 큐로 저장하여 생성해주는 클래스  *****/
public class ObstaclePattern : MonoBehaviour
{
    //장애물 원형
    public GameObject origin_obstacle;
    //장애물의 변 개수
    public int edge_count;
    //장애물 속도
    public float speed;
    //(랜덤)패턴 뒤집기
    public bool reverse_pattern = false;
    //장애물 패턴 목록 => 'T'는 벽, 'F'는 빈칸  ex)FFFFTF (6각형)
    public string[] patternList;
    //장애물 패턴들의 큐
    private Queue<GameObject> q_obstacle;
    //패턴 내의 아이템
    private GameObject itemPrefab;

    /* 패턴을 설정대로 초기화 */
    public void InitPattern()
    {
        //장애물 클래스
        Obstacle obst;
        
        //새로운 큐 생성
        q_obstacle = new Queue<GameObject>();

        //패턴 뒤집기가 true면 50%확률로 패턴을 뒤집음
        //마지막 3줄의 패턴은 변하지 않음 (패턴간의 간격을 위해 고정된 여백)
        if (reverse_pattern)
        {
            if (Random.Range(0, 2) == 0)
            {
                string tmpstr;
                System.Array.Reverse(patternList);
                for (int i = 0; i < patternList.Length - 3; i++)
                {
                    tmpstr = patternList[i];
                    patternList[i] = patternList[i + 3];
                    patternList[i + 3] = tmpstr;
                }
            }
        }
        Debug.Log("===========================");
        //패턴 리스트로부터 순서대로 패턴을 받고 생성
        for (int i = 0; i < patternList.Length; i++)
        {
            Debug.Log(patternList[i]);
            obst = Instantiate(origin_obstacle).GetComponent<Obstacle>();
            //각 장애물의 localScale이 1씩 차이나게 함
            obst.transform.localScale += Vector3.one * i;
            //장애물 상태 초기화
            obst.speed = speed;
            obst.isActive = false;
            //생성된 순서대로 Enqueue
            q_obstacle.Enqueue(obst.gameObject);

            //string으로 된 패턴을 파싱하여 지정된대로 장애물의 형태를 만듬
            //[ F : 빈칸 / T : 벽  / I : 빈칸 + 아이템]
            //11시 방향부터 시계 반대방향의 순서를 가짐
            for (int j = 0; j < edge_count; j++)
            {
                //패턴의 길이가 edge_count보다 짧은 경우(입력 실수 등)
                //뒷부분을 전부 false로 처리
                if (patternList[i].Length <= j)
                {
                    obst.SetObstacleActive(j, false);
                    continue;
                }

                if (patternList[i][j] == 'T')
                {
                    obst.SetObstacleActive(j, true);
                }
                else if (patternList[i][j] == 'F')
                {
                    obst.SetObstacleActive(j, false);
                }
                else if (patternList[i][j] == 'I')
                {
                    if (itemPrefab != null)
                    {
                        GameObject game = GameObject.FindGameObjectWithTag("GameBoard");
                        Instantiate(itemPrefab, game.transform).GetComponent<Item>().Init(speed, j,
                            game.transform.GetChild(3).GetChild(j).position);
                    }
                    obst.SetObstacleActive(j, false);
                }
            }
        }

    }

    /* 큐로부터 장애물을 Dequeue하여 활성화시킨 뒤 반환 */
    public GameObject ActivateDequeueObstacle()
    {
        if (q_obstacle.Count == 0) { return null; }

        GameObject obst = q_obstacle.Dequeue();
        obst.GetComponent<Obstacle>().isActive = true;
        return obst;
    }

    /* 큐의 내용이 비었는지 아닌지를 반환 */
    public bool IsEmpty()
    {
        return q_obstacle.Count == 0;
    }

    /* 현재 큐에 남아있는 장애물의 수를 반환 */
    public int GetCountQueue()
    {
        return q_obstacle.Count;
    }

    /* 패턴 안에 랜덤하게 아이템을 생성 */
    public void CreateRandomItem(GameObject _item)
    {
        /*
        if (_item == null) { return; }

        itemPrefab = _item;
        //랜덤 장애물 라인 선택
        int randLine = Random.Range(0, patternList.Length);
        string pattern = patternList[0];

        //패턴 문자열에서 'F' 중 하나를 골라 I로 변경
        int rand = Random.Range(0, pattern.Length);
        while (pattern[rand] != 'F')
        {
            rand = Random.Range(0, pattern.Length);
        }
        patternList[randLine] = pattern.Substring(0, rand) + "I" + pattern.Substring(rand + 1);
        */
    }

}
