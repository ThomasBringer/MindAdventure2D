using UnityEngine;

public class FallOnTrigger : MonoBehaviour
{
    public Rigidbody2D[] rbs;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Fall(collision.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.enabled)
        {
            Fall(collision.gameObject);
        }
    }

    void Fall(GameObject collidingGo)
    {
        if (collidingGo == Player.player && !Player.playerClass.dead)
        {
            foreach(Rigidbody2D rb in rbs)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}