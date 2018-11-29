﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour {
    public Rigidbody2D rb;
    public float shrinkSpeed = 3f;
	void Start () {

        transform.localScale = Vector3.one * 10f;
        rb.rotation = Random.Range(0, 360f);
	}

    void Update () {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if(transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }
	}
}
