using UnityEngine;
using UnityEngine.UI;

public class MemoryHelper : MonoBehaviour
{
    private int MemoriesIsLooting = 0;
    public Text MemoriesINT;
    [SerializeField] public Movement Movement;
    public GameObject FinishCanvas;
    
    void Start()
    {
        FinishCanvas.SetActive(false);
    }

    void Update()
    {
        if (Movement.Memorys == 4)
        {
            Time.timeScale = 0;
            FinishCanvas.SetActive(true);
        }
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
