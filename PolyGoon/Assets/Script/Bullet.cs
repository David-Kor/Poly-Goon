using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;

    private bool isShoot = false;
    private Vector2 direction;

    void Update()
    {
        if (isShoot)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x) >= 15.0f
                || Mathf.Abs(transform.position.y) >= 15.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ShootBullet(Vector2 firstPos,Vector2 _direct)
    {
        transform.position = firstPos;
        direction = _direct;
        isShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathLine"))
        {
            col.transform.parent.gameObject.SetActive(false);
        }
    }

    public static void ClearBullets()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
    }
}
