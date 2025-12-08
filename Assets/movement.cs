using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 movement;
    public int HP;
    private Player_attack attack;
    private Animator animator;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;

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
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
    }

    public void CollorChange()
    {
        animator.SetTrigger("Collortrigger");
    }
}