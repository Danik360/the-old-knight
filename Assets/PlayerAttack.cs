using UnityEngine;

public class Player_attack : MonoBehaviour
{
    public int EnemyDamage;
    private EnemyAttck EnemyAttack;
    private Animator animator;
    public bool isAttacking;
    public int MyDamage = 2;
    public int HP = 10;

    void Start()
    {
        isAttacking = false;
        animator = GetComponent<Animator>();
        EnemyAttack = GameObject.Find("enemy").GetComponent<EnemyAttck>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartAttack();
        }
        EnemyDamage = EnemyAttack.Damage;
    }

    void StartAttack()
    {
        isAttacking = true;
        // animator.SetTrigger("Attack");
        Invoke("OnAttackEnd", 1);
    }

    public void OnAttackEnd()
    {
        isAttacking = false;
    }

    public void PlayerTakeDamage()
    {
        HP -= EnemyDamage;
        if (HP <= 0)
        {
            Debug.Log("YOU DIED");
// TODO Смерть игрока
            //Die();
        }
    }
}