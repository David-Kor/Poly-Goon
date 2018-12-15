using UnityEngine;

/*****  플레이어의 좌우 회전을 블록하는 클래스  *****/
public class BlockRotate : MonoBehaviour
{
    //해당 blocker가 플레이어의 어느 방향을 담당하는지 알려줌
    //왼쪽 : -1  /  오른쪽 : 1
    public int hor;

    void OnTriggerStay2D(Collider2D col)
    {
        //blocker가 장애물에 닿았을 때
        if (col.CompareTag("Obstacle"))
        {
            //왼쪽 담당이면 왼쪽 방향을 블록 / 오른쪽 담당이면 오른쪽 방향을 블록함
            if (hor < 0) { GetComponentInParent<PlayerInputManager>().LeftBlock(); }
            if (hor > 0) { GetComponentInParent<PlayerInputManager>().RightBlock(); }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //blocker가 장애물로부터 떨어졌을 때
        if (col.CompareTag("Obstacle"))
        {
            //블록 해제
            if (hor < 0) { GetComponentInParent<PlayerInputManager>().LeftUnBlock(); }
            if (hor > 0) { GetComponentInParent<PlayerInputManager>().RightUnBlock(); }
        }
    }
}
