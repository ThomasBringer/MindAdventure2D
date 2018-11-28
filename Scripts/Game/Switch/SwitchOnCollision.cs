using UnityEngine;

public class SwitchOnCollision : SwitchBehaviorAndGameObject
{
    public bool cantCancel;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.enabled)
            Switch(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Switch(collision.gameObject);
    }

    void Switch(GameObject collidingGo)
    {
        if (collidingGo == Player.player && !Player.playerClass.dead)
        {
            SwitchAll(cantCancel);
        }
    }
}