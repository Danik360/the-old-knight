using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float maxVelocity = 10f;

    [Header("Collider Settings")]
    public float colliderRadius = 0.1f;

    private Player_attack attack;
    private Animator animator;
    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private int HP;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetupRigidbody();
        SetupCollider();
    }

    void SetupRigidbody()
    {
        // Критически важные настройки
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true; // Запрещаем физике вращать объект
        rb.gravityScale = 0f; // Отключаем гравитацию если не нужна
    }

    void SetupCollider()
    {
        // Удаляем все старые коллайдеры
        Collider2D[] oldColliders = GetComponents<Collider2D>();
        foreach (var coll in oldColliders)
        {
            Destroy(coll);
        }

        // Добавляем CircleCollider2D (лучший для вращения)
        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius = colliderRadius;
        collider.offset = Vector2.zero;
    }

    void Start()
    {
        attack = GameObject.Find("forwsrd").GetComponent<Player_attack>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        HP = attack.HP;
    }

    void FixedUpdate()
    {
        if (HP > 0)
        {
            HandleMovement();
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void HandleMovement()
    {
        // 1. Движение
        Vector2 input = new Vector2(horizontal, vertical);
        rb.linearVelocity = input * moveSpeed;

        // 2. Вращение (только если движемся)
        if (input.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
            float currentAngle = transform.eulerAngles.z;

            // Плавное вращение
            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle,
                rotationSpeed * Time.fixedDeltaTime);

            // Вращаем через transform, не через Rigidbody
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }

    public void CollorChange()
    {
        animator.SetTrigger("Collortrigger");
    }
    
    // ... остальные методы ...
}