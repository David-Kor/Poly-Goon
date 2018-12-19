using UnityEngine;

/*****  모든 아이템을 관리하고 랜덤으로 선택해주는 클래스  *****/
public class ItemManager : MonoBehaviour
{
    //전체 아이템 리스트
    public GameObject[] itemList;
    //아이템 스폰장소 회전 속도
    public float speed;
    public float minDelay;
    public float maxDelay;

    //각 아이템들의 확률누적값 (가중치)
    private float[] percentages;

    private GameObject spawner;
    private float timer = 0;
    private float spawnDelay = 3.0f;


    void Start()
    {
        spawner = transform.GetChild(0).gameObject;
        spawnDelay = Random.Range(minDelay, maxDelay);

        percentages = new float[itemList.Length];
        float sum = 0.0f;

        //percentages배열에 순서대로 확률 누적값을 넣는다.
        //배열의 마지막에는 항상 100이 온다.(전체 확률 합계값)
        for (int i = 0; i < itemList.Length; i++)
        {
            sum += itemList[i].GetComponent<Item>().percentage;
            percentages[i] = sum;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            Instantiate(SelectRandomItem()).transform.position = spawner.transform.position;
            timer = 0.0f;
            spawnDelay = Random.Range(minDelay, maxDelay);
        }
        if (Time.timeScale != 0)
        {
            transform.Rotate(0f, 0f, speed * -1);
        }
    }


    /* 아이템 목록에서 랜덤으로 선택하여 반환 */
    public GameObject SelectRandomItem()
    {
        float rand = Random.Range(0.0f, 100.0f);

        for (int i = 0; i < percentages.Length; i++)
        {
            if (percentages[i] >= rand)
            {
                return itemList[i];
            }
        }

        return null;
    }
}
