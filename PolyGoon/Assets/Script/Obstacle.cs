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
}
