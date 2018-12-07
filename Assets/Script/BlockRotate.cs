using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotate : MonoBehaviour
{
    public int hor;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            if (hor < 0) { GetComponentInParent<PlayerInputManager>().LeftBlock(); }
            if (hor > 0) { GetComponentInParent<PlayerInputManager>().RightBlock(); }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            if (hor < 0) { GetComponentInParent<PlayerInputManager>().LeftUnBlock(); }
            if (hor > 0) { GetComponentInParent<PlayerInputManager>().RightUnBlock(); }
        }
    }
}
