using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringItem : Item
{
    public override void ItemGet()
    {
        Score.score += score;
        Destroy(gameObject);
    }
}
