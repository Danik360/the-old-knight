using UnityEngine;
using UnityEngine.UI;

public class MemoryHelper : MonoBehaviour
{
    private int MemoriesIsLooting = 0;
    public Text MemoriesINT;
    

    void Start()
    {
       
    }

    void Update()
    {
        if (MemoriesINT != null)
            MemoriesINT.text = $"Записок найденно: {MemoriesIsLooting}";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MemoriesIsLooting++;
            Debug.Log(MemoriesIsLooting);
            if (MemoriesINT != null)
            {
                MemoriesINT.text = $"Записок найденно: {MemoriesIsLooting}";
            }
            Destroy(gameObject);  
        }
    }
}
