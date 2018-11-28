using UnityEngine;

public class DontRespawnOnCollision : MonoBehaviour
{
    public DontRespawnOnLoad dontRespawnClass;

    void OnTriggerEnter2D(Collider2D collision)
    {
        DontRespawn();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DontRespawn();
    }

    void DontRespawn()
    {
        dontRespawnClass.DontRespawn();
    }
}