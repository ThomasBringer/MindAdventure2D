using UnityEngine;

public class KeepFalling : MonoBehaviour
{
    Rigidbody2D rb;

	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update()
    {
        if (rb.bodyType != RigidbodyType2D.Dynamic)
            rb.bodyType = RigidbodyType2D.Dynamic;
    }
}