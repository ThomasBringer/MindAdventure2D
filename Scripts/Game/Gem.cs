using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject burst;
    DontRespawnOnLoad dontRespawnClass;

    void Awake()
    {
        dontRespawnClass = GetComponent<DontRespawnOnLoad>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.player && !Player.playerClass.dead)
        {
            Instantiate(burst, transform.position, Quaternion.identity);
            dontRespawnClass.DontRespawn();
            gameObject.SetActive(false);
        }
    }
}