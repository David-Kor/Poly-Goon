using UnityEngine;

public class Screen : MonoBehaviour
{
    public GameObject screenObject;    //화면에 출력될 이미지 오브젝트

    void Start()
    {
        Instantiate(screenObject, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
    }
}
