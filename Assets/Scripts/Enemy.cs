using UnityEngine;

public class Enemy : BaseEntity
{
    [SerializeField] private float life = 100;
    [SerializeField] private float velocity = 5;
    [SerializeField] private float damage = 100;
    [SerializeField] private float rangeDetecte;
    [SerializeField] private float rangeAttack;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject ColliderAttack;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float x;

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
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);
        animator.SetFloat("Movement", x);
        if (distance <= rangeDetecte)
        {
            x = (target.transform.position.x - transform.position.x);
        }
        if (distance > rangeDetecte)
        {
            x = 0;
        }
        if (distance <= rangeAttack)
        {
            animator.SetTrigger("Attack");
            ColliderAttack.SetActive(true);
        }
        if (distance > rangeAttack)
        {
            ColliderAttack.SetActive(false);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void FixedUpdate()
    {
        Movement(rb,velocity, x);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeDetecte);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, rangeAttack);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            life -= target.GetComponent<PlayerController>().damage;
            Debug.Log(life);
        }
    }
}
