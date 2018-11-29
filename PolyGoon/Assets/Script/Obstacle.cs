using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        transform.localScale -= Vector3.one * speed * Time.deltaTime;
        if (transform.localScale.x < 0) { Destroy(gameObject); }
    }

    public void SetAllObstacleActivse(bool[] active)
    {
        for (int i = 0; i < active.Length; i++)
        {
            transform.GetChild(i).gameObject.SetActive(active[i]);
        }
    }

    public void SetObstacleActive(int index, bool active)
    {
        transform.GetChild(index).gameObject.SetActive(active);
    }
}
