using UnityEngine;

/*****  플레이어의 움직임을 담당하는 클래스  *****/
public class PlayerMovement : MonoBehaviour
{
    //이동 방향
    float moveAxis;
    //이동 속도
    float movementSpeed = 600f;

    void Update()
    {
        moveAxis = Input.GetAxisRaw("Horizontal");
        Move();
    }

    void Move()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -1 * moveAxis * Time.deltaTime * movementSpeed);
    }

}
