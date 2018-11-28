using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathLine")) { GetComponentInParent<PlayerInputManager>().DeadBlock(); Debug.Log("Death!"); }
    }
}
