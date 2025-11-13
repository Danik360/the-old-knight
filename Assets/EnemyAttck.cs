using UnityEngine;

public class EnemyAttck : MonoBehaviour
{
    public int Damage = 1;
    private Player_attack Player;
    
    // Переменные для кулдауна атаки
    private bool canAttack = true;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 1f;
    
    void Start()
    {
        Player = GameObject.Find("forwsrd").GetComponent<Player_attack>();
    }

    void Update()
    {
        // Автоматическая атака с кулдауном
        if (canAttack && IsPlayerInRange())
        {
            AttackPlayer();
        }
    }

    // Проверка расстояния до игрока
    private bool IsPlayerInRange()
    {
        if (Player == null) return false;
        
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        return distance <= attackRange;
    }

    // Метод атаки
    private void AttackPlayer()
    {
        if (Player != null && canAttack)
        {
            Debug.Log("Враг атакует игрока!");
            Player.PlayerTakeDamage();
            StartCoroutine(AttackCooldown());
        }
    }

    // Кулдаун атаки
    private System.Collections.IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        Debug.Log("Враг готов к следующей атаке");
    }

    // Атака при столкновении (триггер)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            Debug.Log("Враг атаковал игрока при столкновении!");
            Player.PlayerTakeDamage();
            StartCoroutine(AttackCooldown());
        }
    }

    // Визуализация радиуса атаки в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}