using UnityEngine;

/*****  (1 Line) 장애물 클래스  *****/
public class Obstacle : MonoBehaviour
{
    //장애물 속도
    public float speed = 2.0f;
    //장애물 활성화 여부. true면 움직이기 시작함
    public bool isActive = false;
    //각 벽들의 로컬위치
    public Vector2[] wallPosition;

    void Update()
    {
        //활성화 시 장애물이 중앙을 향해 움직임
        if (isActive)
        {
            transform.localScale -= Vector3.one * speed * Time.deltaTime;
        }
        //중앙에 도착하면 오브젝트를 삭제
        if (transform.localScale.x < 0) { Destroy(gameObject); }
    }


    /* 장애물의 모든 변(Edge)을 [활성화 / 비활성화] */
    public void SetAllObstacleActivse(bool[] _active)
    {
        for (int i = 0; i < _active.Length; i++)
        {
            transform.GetChild(i).gameObject.SetActive(_active[i]);
        }
    }

    /* 장애물의 해당 변(Edge)을 [활성화 / 비활성화] */
    public void SetObstacleActive(int index, bool _active)
    {
        transform.GetChild(index).gameObject.SetActive(_active);
    }

    public GameObject GetObstacleWall(int index)
    {
        return transform.GetChild(index).gameObject;
    }

    /* 현재 생성된 모든 장애물(Obstacle) 태그의 오브젝트들 제거 (ObstaclePattern 포함) */
    public static void ClearObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
    }
}
