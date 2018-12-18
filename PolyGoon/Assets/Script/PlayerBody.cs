using UnityEngine;

/*****  플레이어의 본체가 특정 오브젝트에 닿았는지를 판정하는 클래스  *****/
public class PlayerBody : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //장애물의 DeadLine에 닿은 경우
        if (col.CompareTag("DeathLine"))
        {
            GetComponentInParent<PlayerInputManager>().PlayerDeath();
        }
        //아이템에 닿은 경우
        if (col.CompareTag("Item"))
        {
            GetComponent<ItemManager>();
        }
    }
}
