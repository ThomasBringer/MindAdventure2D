using System.Collections;
using UnityEngine;

public class StepMovement : MonoBehaviour
{
    public Transform[] transforms;
    public float[] times;
    public float[] breaks;

    void Start()
    {
        transform.position = transforms[0].position;
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        for (; ; )
        {
            for (int i = 0; i != transforms.Length; i++)
            {
                yield return new WaitForSeconds(breaks[i]);
                yield return StartCoroutine(SmoothMovement.Glide(transform, transforms[(i + 1) % transforms.Length].position, times[i]));
            }
        }
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i != transforms.Length; i++)
        {
            Gizmos.DrawLine(transforms[i].position, transforms[(i + 1) % transforms.Length].position);
        }
    }
}