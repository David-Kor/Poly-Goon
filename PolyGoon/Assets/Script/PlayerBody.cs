using UnityEngine;

/*****  플레이어의 본체가 특정 오브젝트에 닿았는지를 판정하는 클래스  *****/
public class PlayerBody : MonoBehaviour
{
    public bool isInvincible = false;

    void Start()
    {
        isInvincible = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //무적 상태가 아님 && 장애물의 DeadLine에 닿은 경우
        if (!isInvincible && col.CompareTag("DeathLine"))
        {
            GetComponentInParent<PlayerInputManager>().PlayerDeath();
        }
        if (col.CompareTag("Item"))
        {
            col.GetComponent<Item>().ItemGet();
        }
    }
}
