using UnityEngine;

/*****  모든 아이템의 부모 클래스  *****/
public class Item : MonoBehaviour
{
    public int score;
    public float speed = 2.0f;
    public float percentage;

    protected Vector3 negativeInitPosition;
    //이동 방향
    protected Vector3 direction;

    protected void Start()
    {
        //처음 위치의 역수
        negativeInitPosition = transform.position * -1;
        //정중앙(0, 0)을 바라보는 방향
        direction = negativeInitPosition.normalized;
    }

    protected void Update()
    {
        //이동
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        //완전히 반대편까지 이동하면 제거
        if (Mathf.Abs(transform.position.x - negativeInitPosition.x) <= 0.1f ||
            Mathf.Abs(transform.position.y - negativeInitPosition.y) <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    /* 해당 아이템이 가진 점수를 가산 */
    public void Scoring()
    {
        Score.score += score;
        Destroy(gameObject);
    }

    /* 생성된 모든 아이템 제거 */
    public static void ClearItems()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < items.Length; i++)
        {
            Destroy(items[i]);
        }
    }
}
