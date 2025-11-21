using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Движение
        Vector2 movement = new Vector2(horizontal, vertical);
        rb.linearVelocity = movement * moveSpeed;

        // Поворот в сторону движения
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(-movement.x, movement.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    public void CollorChange()
    {
        animator.SetTrigger("Collortrigger");
    }
}