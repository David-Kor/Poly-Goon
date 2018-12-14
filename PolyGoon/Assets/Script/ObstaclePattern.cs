using System.Collections.Generic;
using UnityEngine;

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
    //장애물 패턴 목록
    public string[] patternList;
    //장애물 패턴들의 큐
    private Queue<GameObject> q_obstacle;

    public void InitPattern()
    {
        Obstacle obst;
        q_obstacle = new Queue<GameObject>();
        
        //패턴 뒤집기가 true면 50%확률로 패턴을 뒤집음
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

        for (int i = 0; i < patternList.Length; i++)
        {
            obst = Instantiate(origin_obstacle).GetComponent<Obstacle>();
            obst.transform.localScale += Vector3.one * i;
            obst.speed = speed;
            obst.active = false;
            q_obstacle.Enqueue(obst.gameObject);


            for (int j = 0; j < edge_count; j++)
            {
                //패턴의 길이가 edge_count보다 짧은 경우(입력 실수)
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
            }
        }

    }

    public GameObject ActivateDequeueObstacle()
    {
        if (q_obstacle.Count == 0) { return null; }

        GameObject obst = q_obstacle.Dequeue();
        obst.GetComponent<Obstacle>().active = true;
        return obst;
    }

    public bool IsEmpty()
    {
        return q_obstacle.Count == 0;
    }

    public int GetCountQueue()
    {
        return q_obstacle.Count;
    }

}
