using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public GameObject[] patternList;
    
    private ObstaclePattern pattern;
    public GameObject lastObstacle;
    private bool doCreatPattern;
    private int index;

    void Start()
    {
        lastObstacle = null;
        doCreatPattern = true;
        pattern = null;
    }

    void Update()
    {
        if (doCreatPattern)
        {
            doCreatPattern = false;
            index = Random.Range(0, patternList.Length);
            pattern = Instantiate(patternList[index]).GetComponent<ObstaclePattern>();
            pattern.InitPattern();

            int count = pattern.GetCountQueue();
            for (int i = 0; i < count; i++)
            {
                lastObstacle = pattern.ActivateDequeueObstacle();
                if (lastObstacle == null) { break; }
            }
            Destroy(pattern);
        }

        if (lastObstacle != null)
        {
            if (lastObstacle.transform.localScale.x <= 9f)
            {
                doCreatPattern = true;
                lastObstacle = null;
            }
        }
    }
}
