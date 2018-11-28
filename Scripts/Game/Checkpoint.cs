using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointOrder;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.player && !Player.playerClass.dead && checkpointOrder > Player.GetCheckpointCount())
            Player.Checkpoint(transform.position, checkpointOrder);
    }
}