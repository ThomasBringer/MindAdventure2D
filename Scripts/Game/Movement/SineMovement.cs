using UnityEngine;

public class SineMovement : SaveTimer
{
    public Transform height;
    public float speed;

    Vector2 origin;

    void Awake()
    {
        origin = transform.position;
    }

    void Update()
    {
        transform.position = origin + SmoothMovement.SineWave(Time.time - savedTimer,speed, GetHeight() - origin);
    }

    Vector2 GetHeight()
    {
        return height.position;
    }

    void OnDrawGizmos()
    {
        Vector2 position;
        if (Application.isPlaying)
            position = origin;
        else
            position = transform.position;

        Gizmos.DrawLine(GetHeight(), position * 2 - GetHeight());
    }
}