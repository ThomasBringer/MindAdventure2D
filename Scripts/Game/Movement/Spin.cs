using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed;

	void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}