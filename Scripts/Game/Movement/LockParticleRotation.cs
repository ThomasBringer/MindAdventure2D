using UnityEngine;

public class LockParticleRotation : MonoBehaviour
{
    ParticleSystem particle;
    ParticleSystem.ShapeModule shape;

    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        shape = particle.shape;
    }

    void LateUpdate()
    {
        shape.rotation = new Vector3(-90, 0, -transform.eulerAngles.z);
    }
}