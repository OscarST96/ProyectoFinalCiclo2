using UnityEngine;

public class PlayerController : BaseEntity
{
    [SerializeField] private float life = 100;
    public float damage = 5;
    [SerializeField] private float velocity = 1;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private GameObject ColliderAttack;

    private float x;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool capJump = false;
    private bool OnMovement = true;

    public float Life
    {
        get { return life; }
        set 
        {
            if ((value) <= 0)
            {
                life = 0; 
                return; 
            }
            else if (value >= 100)
            {
                life = 100;
            }
            else
            {
                life = value;
            }
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ColliderAttack.SetActive(false);
        life = 100;
    }
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Movement", x);

        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(rb2d, jumpForce, capJump);
        }
        animator.SetBool("Jump", capJump);
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Attack");
            ColliderAttack.SetActive(true);
            Invoke("DesactiveObject", 0.2f);
        }
        if (life == 0)
        {
            animator.SetTrigger("Dead");
        }
    }
    private void FixedUpdate()
    {
        if (OnMovement)
        {
            Movement(rb2d, velocity, x);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            capJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            capJump = false;
        }
    }
    private void DesactiveObject()
    {
        ColliderAttack.SetActive(false);
    }
}