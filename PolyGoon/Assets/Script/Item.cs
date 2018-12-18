using UnityEngine;

/*****  모든 아이템의 부모 클래스  *****/
public class Item : MonoBehaviour
{
    public int score;
    public float percentage;
    private float speed;

    void Update()
    {
        transform.Translate((Vector3.zero - transform.position).normalized * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) <= 0.5f || Mathf.Abs(transform.position.y) <= 0.5f)
        {
            Destroy(gameObject);
        }
    }

    public void Init(float _speed, int index, Vector3 pos)
    {
        transform.position = pos ;
        speed = _speed;
    }

    public void Scoring()
    {
        Score.score += score;
    }
}
