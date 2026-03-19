using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject playerObj;
    public float speed = 3f;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerObj != null)
        {
            Vector3 direction = (playerObj.transform.position - transform.position).normalized;

            // поворот: враг «смотрит» в сторону игрока
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

            // движение вперёд по направлению, в котором враг «смотрит»
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
            // здесь: Vector3.up в Space.Self = вперёд по текущей ориентации
        }
    }
}
