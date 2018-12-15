using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public float speed = 2.0f;
    private bool isDead;
    private bool l_block;
    private bool r_block;

    void Start()
    {
        l_block = false;
        r_block = false;
        isDead = false;
    }

    void Update()
    {
        //죽었을 경우 시간을 멈춤
        if (isDead) { Time.timeScale = 0; return; }
        //게임의 블록을 해제하면 다시 시간이 흐름
        else if (Time.timeScale != 1) { Time.timeScale = 1; }

        //left키 입력 AND l_block상태가 아닐 때
        if (Input.GetKey("left") && !l_block)
        {
            transform.Rotate(0f, 0f, speed);
        }
        //right키 입력 AND r_block상태가 아닐 때
        if (Input.GetKey("right") && !r_block)
        {
            transform.Rotate(0f, 0f, speed * -1);
        }
    }

    public void LeftBlock()
    {
        if (!r_block) { l_block = true; }
    }

    public void RightBlock()
    {
        if (!l_block) { r_block = true; }
    }
    public void LeftUnBlock() { l_block = false; }

    public void RightUnBlock() { r_block = false; }

    public void DeadBlock() { isDead = true; }

    public void Restart() { isDead = false; }
}
