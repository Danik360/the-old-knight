using UnityEngine.UI;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public GameObject MindBreakerCanvas;
    public Image MindBreak;
    public Image heartsImage;
    public Image HPBar;
    public int HP;
    public int maxHP = 4;
    public Sprite[] Hearts;
    [SerializeField] private movement playerMovement;

    void Start()
    {
        MindBreakerCanvas.SetActive(false);
        
        // Получаем компоненты через Inspector или через поиск
        if (heartsImage == null)
        {
            var heartsObj = GameObject.Find("Hearts");
            if (heartsObj != null)
            {
                heartsImage = heartsObj.GetComponent<Image>();
            }
        }

        if (heartsImage == null)
        {
            Debug.LogError("Hearts Image component not found!");
        }
    }

    void Update()
    {
        // Обновляем спрайт сердца в зависимости от HP
        if (heartsImage != null && Hearts != null && Hearts.Length > 0)
        {
            // Ensure HP doesn't exceed array bounds
            int heartIndex = Mathf.Clamp(maxHP - HP, 0, Hearts.Length - 1);
            if (heartIndex < Hearts.Length)
            {
                heartsImage.sprite = Hearts[heartIndex];
            }
            
            if (HP <= 0)
            {
                MindBreakerCanvas.SetActive(true);
            }
        }
    }
    
    [SerializeField] private movement playerMovement;
    
    [Header("Damage Settings")]
    [SerializeField] private int defaultDamage = 1;
    [SerializeField] private bool canTakeDamage = true;
    
    public void PlayerTakeDamage(int damage = -1)
    {
        // Use default damage if not specified
        if (damage == -1) damage = defaultDamage;
        
        if (!canTakeDamage) return;
        
        HP -= damage;
        HP = Mathf.Clamp(HP, 0, maxHP); // Ensure HP stays within bounds
        
        // Trigger color change effect through movement script
        if (playerMovement != null)
        {
            playerMovement.CollorChange();
        }
        
        if (HP <= 0)
        {
            Debug.Log("YOU DIED");
            OnPlayerDeath();
        }
    }
    
    private void OnPlayerDeath()
    {
        // Disable taking damage when dead
        canTakeDamage = false;
        // TODO Смерть игрока - добавьте реализацию смерти
    }
    
    public void EnableDamageTaking(bool enable)
    {
        canTakeDamage = enable;
    }
    
    public bool CanTakeDamage()
    {
        return canTakeDamage && HP > 0;
    }
    
    public void Heal(int amount)
    {
        HP += amount;
        HP = Mathf.Clamp(HP, 0, maxHP);
    }
    
    public bool IsAlive()
    {
        return HP > 0;
    }
    
    public void ResetHP()
    {
        HP = maxHP;
    }
}