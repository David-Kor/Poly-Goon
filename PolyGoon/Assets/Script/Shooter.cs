using UnityEngine;

public class Shooter : ActiveItem
{
    public override void ItemActive()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>().ShooterMount();
    }
}
