using UnityEngine;
using UnityEngine.UI;

public class MemoryHelper : MonoBehaviour
{
    private int MemoriesIsLooting = 0;
    public Text MemoriesINT;
    [SerializeField] public Movement Movement;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (MemoriesINT != null)
            MemoriesINT.text = $"Записок найденно: {Movement.Memorys}";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Movement.MemoryCounter();
            if (MemoriesINT != null)
            {
                MemoriesINT.text = $"Записок найденно: {MemoriesIsLooting}";
            }
            Destroy(gameObject);  
        }
    }
}
