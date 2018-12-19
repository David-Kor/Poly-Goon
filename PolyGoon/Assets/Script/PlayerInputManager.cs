using UnityEngine;

/*****  플레이어의 모든 키보드 입력을 처리하는 클래스 *****/
public class PlayerInputManager : MonoBehaviour
{
    //게임 오버 UI창
    public GameObject gameOverUI;

    public float speed = 2.0f;
    private bool isDead;
    
    //플레이어가 벽의 옆면(left / right)에 닿았는지 알려줌
    private bool l_block;
    private bool r_block;

    //쉴드 아이템 효과를 위한 변수들
    private bool isInvincible;
    private float invincibleTime;
    private float timer;

    //슈터 아이템 효과를 위한 변수들
    public GameObject bullet;
    private bool isShooterMount;

    void Start()
    {
        l_block = false;
        r_block = false;
        isDead = false;
        isInvincible = false;
        Time.timeScale = 1f;
        invincibleTime = 0f;
        timer = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        //죽었을 경우 시간을 멈춤
        if (isDead) { Time.timeScale = 0; return; }
        //재시작하면 다시 시간이 흐름
        else if (Time.timeScale != 1f) { Time.timeScale = 1f; }

        //left키 입력 AND 왼쪽 블록상태가 아닐 때
        if (Input.GetKey("left") && !l_block)
        {
            transform.Rotate(0f, 0f, speed);
        }
        //right키 입력 AND 오른쪽 블록상태가 아닐 때
        if (Input.GetKey("right") && !r_block)
        {
            transform.Rotate(0f, 0f, speed * -1);
        }

        //무적이 활성화된 경우
        if (isInvincible)
        {
            timer += Time.deltaTime;
            //지속시간이 끝난 경우
            if (timer >= invincibleTime) { NoInvincibility(); }
        }

        //슈터가 장착된 경우
        if (isShooterMount)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                Instantiate(bullet).GetComponent<Bullet>().ShootBullet(transform.GetChild(0).GetChild(1).position ,transform.up);
                ShooterRelease();
            }
        }
    }

    
    /* 한쪽 방향의 이동을 블록 */
    public void LeftBlock()
    {
        if (!r_block) { l_block = true; }
    }
    public void RightBlock()
    {
        if (!l_block) { r_block = true; }
    }

    /* 이동 블록 해제 */
    public void LeftUnBlock() { l_block = false; }
    public void RightUnBlock() { r_block = false; }

    /* 장애물의 Deadline에 닿은 경우 호출됨 */
    public void PlayerDeath()
    {
        isDead = true;
        
        //게임오버 UI를 활성화
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            gameOverUI.GetComponent<GameResultController>().SaveRecord();
        }
    }

    /* 재시작 버튼(R) 입력 시 동작 */
    public void Restart()
    {
        gameOverUI.GetComponent<GameResultController>().SaveRecord();
        gameOverUI.SetActive(false);
        Score.score = 0;
        Reset();
    }

    /* 상태 초기화 */
    public void Reset()
    {
        isDead = false;
        Time.timeScale = 1f;
        l_block = false;
        r_block = false;
        Obstacle.ClearObstacles();
        Item.ClearItems();
        NoInvincibility();
        ShooterRelease();
    }


    /* 무적 상태 발동 */
    public void Invincibility(float _time)
    {
        invincibleTime = _time;
        isInvincible = true;
        GetComponentInChildren<PlayerBody>().isInvincible = true;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        timer = 0f;
    }

    public void NoInvincibility()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        GetComponentInChildren<PlayerBody>().isInvincible = false;
        invincibleTime = 0f;
        isInvincible = false;
        timer = 0f;
    }

    public void ShooterMount()
    {
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        isShooterMount = true;
    }

    public void ShooterRelease()
    {
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        isShooterMount = false;
    }
}
