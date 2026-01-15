using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float maxVelocity = 10f;

    [Header("Collider Settings")]
    [SerializeField] private float colliderRadius = 0.1f;  // ← Радиус коллайдера
    [SerializeField] private Vector2 colliderOffset = Vector2.zero;  // ← Смещение коллайдера
    [SerializeField] private bool useContinuousCollision = true;  // ← Непрерывная коллизия
    [SerializeField] private bool isTrigger = false;  // ← Триггер или коллизия

    [Header("References")]
    [SerializeField] private HPSystem playerStats;
    [SerializeField] private Animator playerAnimator;
    
    private Animator animator;
    private Rigidbody2D rb;
    private CircleCollider2D playerCollider;  // ← Ссылка на коллайдер
    private float horizontal;
    private float vertical;
    private int currentHP;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetupRigidbody();
        SetupCollider();
    }

    void SetupRigidbody()
    {
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = useContinuousCollision ? 
            CollisionDetectionMode2D.Continuous : CollisionDetectionMode2D.Discrete;
        rb.freezeRotation = true;
        rb.gravityScale = 0f;
    }

    void SetupCollider()
    {
        // Находим существующий коллайдер
        playerCollider = GetComponent<CircleCollider2D>();
        
        // Удаляем старые коллайдеры (кроме нашего)
        Collider2D[] oldColliders = GetComponents<Collider2D>();
        foreach (var coll in oldColliders)
        {
            if (coll != playerCollider)
                DestroyImmediate(coll);
        }

        // Создаем новый или настраиваем существующий
        if (playerCollider == null)
        {
            playerCollider = gameObject.AddComponent<CircleCollider2D>();
        }

        // ← НАСТРОЙКА РАДИУСА И ПАРАМЕТРОВ
        playerCollider.radius = colliderRadius;
        playerCollider.offset = colliderOffset;
        playerCollider.isTrigger = isTrigger;

        Debug.Log($"Коллайдер настроен: радиус={colliderRadius}, смещение={colliderOffset}");
    }

    void Start()
    {
        // Use serialized references if available, otherwise get component
        animator = playerAnimator != null ? playerAnimator : GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        // Пересоздаем коллайдер при старте (если нужно)
        SetupCollider();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        if (playerStats != null)
        {
            currentHP = playerStats.HP;
        }
    }

    void FixedUpdate()
    {
        if (currentHP > 0)
        {
            HandleMovement();
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            // Optionally play death animation here
            if (animator != null)
            {
                animator.SetBool("IsDead", true);
            }
        }
    }

    void HandleMovement()
    {
        Vector2 input = new Vector2(horizontal, vertical);
        rb.linearVelocity = input * moveSpeed;

        if (input.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
            float currentAngle = transform.eulerAngles.z;

            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }

    public void CollorChange()
    {
        animator.SetTrigger("Collortrigger");
    }

    // ← ПУБЛИЧНЫЕ МЕТОДЫ ДЛЯ ИЗМЕНЕНИЯ РАДИУСА ВО ВРЕМЯ ИГРЫ
    public void SetColliderRadius(float newRadius)
    {
        colliderRadius = newRadius;
        if (playerCollider != null)
        {
            playerCollider.radius = newRadius;
            Debug.Log($"Радиус коллайдера изменен на: {newRadius}");
        }
    }

    public float GetColliderRadius()
    {
        return playerCollider != null ? playerCollider.radius : colliderRadius;
    }

    // ← ВИЗУАЛИЗАЦИЯ КОЛЛАЙДЕРА В SCENE VIEW
    private void OnDrawGizmosSelected()
    {
        if (playerCollider != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + (Vector3)playerCollider.offset, 
                playerCollider.radius);
        }
    }
}
