using UnityEngine;

public class Shield : ActiveItem
{
    public float shieldTime;

    public override void ItemActive()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>().Invincibility(shieldTime);
    }
}
