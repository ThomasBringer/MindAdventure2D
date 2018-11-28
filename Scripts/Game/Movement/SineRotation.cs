using UnityEngine;

public class SineRotation : SaveTimer
{
    public float angle;
    public float speed;

    Quaternion origin;

    void Awake()
    {
        origin = transform.rotation;
    }

    void Update()
    {
        transform.eulerAngles = origin.eulerAngles + Vector3.forward * SmoothMovement.SineWave(Time.time - savedTimer, speed, angle);
    }

    void OnDrawGizmos()
    {
        DrawLine(new Vector2(Mathf.Cos(Mathf.Deg2Rad * (90 + angle)), Mathf.Sin(Mathf.Deg2Rad * (90 + angle))), 100);
        DrawLine(new Vector2(Mathf.Cos(Mathf.Deg2Rad * (90 - angle)), Mathf.Sin(Mathf.Deg2Rad * (90 - angle))), 100);
    }

    void DrawLine(Vector2 line, float multiplier)
    {
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + multiplier * line);
    }
}