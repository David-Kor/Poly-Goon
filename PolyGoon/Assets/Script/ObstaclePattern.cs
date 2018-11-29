using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePattern : MonoBehaviour
{
    public GameObject origin_obstacle;
    public int edge_count;
    public string[] patternList;
    public Queue<GameObject> q_pattern;

    void Start()
    {
        Obstacle obst;
        for (int i = 0; i < patternList.Length; i++)
        {
            obst = Instantiate(origin_obstacle).GetComponent<Obstacle>();
            obst.transform.localScale += Vector3.one * i;
            for (int j = 0; j < edge_count; j++)
            {
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

}
