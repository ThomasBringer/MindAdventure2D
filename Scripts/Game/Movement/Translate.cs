using UnityEngine;

public class Translate : MonoBehaviour
{
    public Vector2 speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, Space.World);
    }
}