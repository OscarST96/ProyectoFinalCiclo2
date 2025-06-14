using UnityEngine;

public class PlayerController : BaseEntity
{
    [SerializeField] private float velocity = 1;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private float cadence = 1;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator animator;

    private float x;
    private Rigidbody2D rb2d;
    private bool OnJump = false;
    private bool OnMovement = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        animator.SetFloat("Movement", x * velocity);

        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        animator.SetBool("OnJump", OnJump);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(rb2d, jumpForce, OnJump);
        }

        //Shoot();
    }
    private void FixedUpdate()
    {
        Movement(rb2d, velocity, x);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            OnJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnJump = false;
    }
}