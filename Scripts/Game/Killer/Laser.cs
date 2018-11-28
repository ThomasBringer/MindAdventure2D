using UnityEngine;

public class Laser : Killer
{
    RaycastHit2D[] hits;
    ParticleSystem particle;
    ParticleSystem.MainModule main;

    public float maxLength;
    float length;

    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        main = particle.main;
    }

    void LateUpdate()
    {
        length = maxLength;
        hits = Physics2D.RaycastAll(transform.position, transform.up, length);

        if (hits.Length != 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (!hit.collider.isTrigger)
                {
                    length = Vector2.Distance(transform.position, hit.point);
                    KillGo(hit.collider.gameObject);
                    break;
                }
            }
        }
        main.startLifetime = length / main.startSpeed.constant;
    }
}