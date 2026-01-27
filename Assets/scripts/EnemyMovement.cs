using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject playerObj;
    public float speed = 3f;
    
    void Start()
    {
        // Убрал повторное объявление GameObject - используем поле класса
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Проверяем что playerObj не null
        if (playerObj != null)
        {
            // Правильное обращение к позиции игрока
            Vector3 direction = (playerObj.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}