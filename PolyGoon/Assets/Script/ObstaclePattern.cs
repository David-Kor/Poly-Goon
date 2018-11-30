using System.Collections.Generic;
using UnityEngine;

public class ObstaclePattern : MonoBehaviour
{
    public GameObject origin_obstacle;
    public int edge_count;
    public float speed;
    public string[] patternList;
    private Queue<GameObject> q_obstacle;    //장애물 큐

    public void InitPattern()
    {
        Obstacle obst;
        q_obstacle = new Queue<GameObject>();

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
