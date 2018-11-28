using System.Collections;
using UnityEngine;

public static class SmoothMovement
{
    static Vector2 GetPos(Transform transform, bool local)
    {
        return local ? transform.localPosition : transform.position;
    }

    static void SetPos(Vector2 newPos, Transform transform, bool local)
    {
        if (local)
        {
            transform.localPosition = newPos;
        }
        else
        {
            transform.position = newPos;
        }
    }

    public static IEnumerator Follow(Transform transform, Transform target, float smoothTime, bool local = false, bool infinite = false)
    {
        Vector2 velocity = Vector2.zero;
        while (infinite ? true : !Mathf.Approximately(Vector2.Distance(GetPos(transform, local), target.position), 0))
        {

            SetPos(Vector2.SmoothDamp(transform.position, target.position, ref velocity, smoothTime), transform, local);
            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator Glide(Transform transform, Vector2 target, float time, bool local = false)
    {
        Vector2 origin = GetPos(transform, local);
        int axis;
        int sign;
        if (target.x - GetPos(transform, local).x == 0)
        {
            if (target.y - GetPos(transform, local).y == 0)
            {
                yield break;
            }
            else
            {
                axis = 1;
            }
        }
        else
        {
            axis = 0;
        }

        if (target[axis] - GetPos(transform, local)[axis] > 0)
            sign = 1;
        else
            sign = -1;

        while ((target[axis] - GetPos(transform, local)[axis]) * sign > 0)
        {

            SetPos((target - origin) * (Time.deltaTime / time) + GetPos(transform, local), transform, local);
            yield return null;
        }
        if (target != GetPos(transform, local))
            SetPos(target, transform, local);
    }

    public static float SineWave(float timer, float speed, float height)
    {
        return Mathf.Sin(timer * speed) * height;
    }

    public static Vector2 SineWave(float timer, float speed, Vector2 height)
    {
        return Mathf.Sin(timer * speed) * height;
    }
}