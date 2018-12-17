using UnityEngine;

/*****  플레이어가 DeathLine에 닿았는지를 판정하는 클래스  *****/
public class PlayerBody : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathLine"))
        {
            GetComponentInParent<PlayerInputManager>().PlayerDeath();
        }
    }
}
