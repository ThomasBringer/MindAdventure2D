using UnityEngine;

public class Character : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;

    enum ColliderNames { Default, Small, Die };
    public BoxCollider2D boxCollider;
    public BoxCollider2D smallBoxCollider;
    public BoxCollider2D dieBoxCollider;

    protected bool grounded;
    protected bool crouched;
    public bool dead;
    public LayerMask environment;

    public float jumpHeight;
    public float speed;
    public bool airJump;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ChangeCollider(ColliderNames.Default);
    }

    void ChangeColliderIf(bool condition, ColliderNames name)
    {
        ChangeCollider(condition ? name : ColliderNames.Default);
    }

    void ChangeCollider(ColliderNames name)
    {
        boxCollider.enabled = name == ColliderNames.Default;
        smallBoxCollider.enabled = name == ColliderNames.Small;
        dieBoxCollider.enabled = name == ColliderNames.Die;
    }

    protected virtual void Update()
    {
        grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - boxCollider.size.x / 2 + 0.5f, transform.position.y - boxCollider.size.y / 2 + boxCollider.offset.y - 2), new Vector2(transform.position.x + boxCollider.size.x / 2 - 0.5f, transform.position.y - boxCollider.size.y / 2 + boxCollider.offset.y), environment);
        anim.SetBool("Grounded", grounded);

        anim.SetFloat("YVelocity", rb.velocity.y);
    }

    protected void Walk(float multiplier)
    {
        float finalSpeed = speed * multiplier;
        if (crouched)
        {
            finalSpeed = 0;
        }
        if (finalSpeed != 0)
            transform.localScale = new Vector2(Mathf.Sign(finalSpeed), 1);

        anim.SetFloat("XVelocity", Mathf.Abs(finalSpeed));
        rb.velocity = new Vector2(finalSpeed, rb.velocity.y);
    }

    protected void Jump(float multiplier)
    {
        if (!crouched && grounded || airJump)
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight * multiplier);
    }

    protected void Crouch(bool crouch)
    {
        if (grounded)
        {
            crouched = crouch;
            anim.SetBool("Crouched", crouch);

            ChangeColliderIf(crouch, ColliderNames.Small);
        }
    }

    public virtual void Die(bool die)
    {
        dead = die;
        anim.SetBool("Dead", die);

        Crouch(false);
        rb.velocity = Vector2.zero;

        ChangeColliderIf(die, ColliderNames.Die);
    }
}