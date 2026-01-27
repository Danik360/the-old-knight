using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour
{
    private Player_attack attack;
    public bool isAttacking;
    [SerializeField] private GameObject attackCollision;
    
    private BoxCollider2D attackCollider;
    private Bounds bounds;
    private Vector2 minCorner;
    private Vector2 maxCorner;
    private Collider2D[] hitEnemys;

    // Переменные для перезарядки
    private bool canAttack = true;
    private bool hasHitThisAttack = false;
    [SerializeField] private float attackCooldown = 0.5f;

    void Start()
    {
        attack = GameObject.Find("forwsrd").GetComponent<Player_attack>();
        
        if (attackCollision != null)
        {
            attackCollider = attackCollision.GetComponent<BoxCollider2D>();
            if (attackCollider != null)
            {
                bounds = attackCollider.bounds;
                minCorner = bounds.min;
                maxCorner = bounds.max;
            }
        }
    }

    void Update()
    {
        isAttacking = attack.isAttacking;
        
        if (attackCollider != null)
        {
            bounds = attackCollider.bounds;
            minCorner = bounds.min;
            maxCorner = bounds.max;
            
            hitEnemys = Physics2D.OverlapAreaAll(bounds.min, bounds.max);
            
            if (isAttacking && canAttack && !hasHitThisAttack && hitEnemys.Length > 0)
            {
                hasHitThisAttack = true;
                
                foreach (Collider2D enemyCollider in hitEnemys)
                {
                    if (enemyCollider.CompareTag("Enemy") && enemyCollider.gameObject != attackCollision)
                    {         
                        // Наносим урон конкретному врагу
                        EnemyHP enemy = enemyCollider.GetComponent<EnemyHP>();
                        if (enemy != null)
                        {
                            enemy.TakeDamage();
                        }
                    }
                }

                StartCoroutine(AttackCooldown());
            }
        }

        if (!isAttacking && hasHitThisAttack)
        {
            hasHitThisAttack = false;
        }
    }

    private System.Collections.IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        hasHitThisAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackCollider != null)
        {
            Gizmos.color = canAttack ? Color.green : Color.red;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}