
public abstract class ActiveItem : Item
{
    public override void ItemGet()
    {
        Score.score += score;
        ItemActive();
        Destroy(gameObject);
    }
    public abstract void ItemActive();
}
