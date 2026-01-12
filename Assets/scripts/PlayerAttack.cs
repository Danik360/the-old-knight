using UnityEngine;

public class Player_attack : MonoBehaviour
{
    private Movement PlayerAnim;
    public int EnemyDamage;
    private EnemyAttck EnemyAttack;
    private Animator animator;
    public bool isAttacking;
    public int MyDamage = 2;
    public int HP = 4;

    void Start()
    {
        PlayerAnim = GameObject.Find("player").GetComponent<Movement>();
        isAttacking = false;
        animator = GetComponent<Animator>();
        
        // Поиск врага по тегу "Enemy"
        GameObject enemyObj = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyObj != null)
        {
            EnemyAttack = enemyObj.GetComponent<EnemyAttck>();
            if (EnemyAttack != null)
            {
                Debug.Log("Враг найден по тегу: " + enemyObj.name);
            }
            else
            {
                Debug.LogError("Компонент EnemyAttck не найден на объекте с тегом 'Enemy'");
            }
        }
        else
        {
            Debug.LogError("Объект с тегом 'Enemy' не найден в сцене");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartAttack();
        }
        
        // Безопасное обращение к EnemyAttack
        if (EnemyAttack != null)
        {
            EnemyDamage = EnemyAttack.Damage;
        }
        else
        {
            EnemyDamage = 1; // Значение по умолчанию
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        animator.SetTrigger("attackTrigger");
        Invoke("OnAttackEnd", 1);
    }

    public void OnAttackEnd()
    {
        isAttacking = false;
    }

    public void PlayerTakeDamage()
    {
        HP -= EnemyDamage;
        if (PlayerAnim != null)
            {
                PlayerAnim.CollorChange();
            }
        if (HP <= 0)
        {
            Debug.Log("YOU DIED");
            // TODO Смерть игрока
        }
    }
}