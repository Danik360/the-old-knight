using UnityEngine;
using UnityEngine.UI;

public class MemoryHelper : MonoBehaviour
{
    private int MemoriesIsLooting;
    public Text MemoriesINT;
    public GameObject Me;

    void Start()
    {
        MemoriesIsLooting = 0;
    }

    void Update()
    {
        MemoriesINT.text = $"Записок найденно: {MemoriesIsLooting}";
    }

    void OnCollision2D(Collision2D other)
    {
        // Проверка столкновения с игроком
        if (other.gameObject.CompareTag("Player"))
        {
            MemoriesIsLooting += 1;
            Destroy(Me);
        }
    }
}
