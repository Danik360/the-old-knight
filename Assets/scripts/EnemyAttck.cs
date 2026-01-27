using UnityEngine;
using System.Collections;

public class EnemyAttck : MonoBehaviour
{
    public int Damage = 1;
    private HPSystem Player;
    
    private bool canAttack = true;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 0.6f;
    
    void Start()
    {
        // Поиск игрока по тегу "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            Player = playerObj.GetComponent<HPSystem>();
        }
    }

    void Update()
    {
        if (canAttack && IsPlayerInRange())
        {
            AttackPlayer();
        }
    }

    private bool IsPlayerInRange()
    {
        if (Player == null) return false;
        
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        return distance <= attackRange;
    }

    private void AttackPlayer()
    {
        if (Player != null && canAttack)
        {
            StartCoroutine(AttackCooldown());
        }
    }

    private System.Collections.IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canAttack && Player != null)
        {
            Player.PlayerTakeDamage();
            StartCoroutine(AttackCooldown());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}