using UnityEngine;

public class LockRotation : MonoBehaviour
{
	void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
	}
}