using UnityEngine;

public class KillerOnCollision : Killer
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        KillGo(collision.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        KillGo(collision.gameObject);
    }
}