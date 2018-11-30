using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    float moveAxis;
    float movementSpeed = 600f;

    void Update () {
        moveAxis = Input.GetAxisRaw("Horizontal");
        Move();
    }

    void Move()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -moveAxis * Time.deltaTime * movementSpeed);
    }
    
}
