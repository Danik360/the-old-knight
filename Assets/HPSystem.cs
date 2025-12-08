using UnityEngine.UI;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public GameObject MindBreakerCanvas;
    public Image MindBreak;
    public Image spriteRenderer;
    public Image HPBar;
    public int HP;
    public Player_attack PlayerHP;
    public Sprite[] Hearts;
    
    void Start()
    {
        MindBreakerCanvas.SetActive(false);
        // Более безопасный поиск объектов
        PlayerHP = GameObject.Find("forwsrd")?.GetComponent<Player_attack>();
        spriteRenderer = GameObject.Find("Hearts")?.GetComponent<Image>();
        
        if (PlayerHP == null)
        {
            Debug.LogError("Player_attack component not found!");
        }
        
        if (spriteRenderer == null)
        {
            Debug.LogError("Hearts Image component not found!");
        }
    }

    void Update()
    {
        // Обновляем HP каждый кадр
        if (PlayerHP != null)
        {
            HP = PlayerHP.HP;
        }
        
        // Обновляем спрайт сердца в зависимости от HP
        if (spriteRenderer != null && Hearts != null && Hearts.Length > 0)
        {
            if (HP <= 0)
            {
                spriteRenderer.sprite = Hearts[0];
                MindBreakerCanvas.SetActive(true);
            }
            else if (HP == 1)
            {
                spriteRenderer.sprite = Hearts[1];
            }
            else if (HP == 2)
            {
                spriteRenderer.sprite = Hearts[2];
            }
            else if (HP == 3)
            {
                spriteRenderer.sprite = Hearts[3];
            }
            else if (HP == 4)
            {
                spriteRenderer.sprite = Hearts[4];
            }
        }
    }
}