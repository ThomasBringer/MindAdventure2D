using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static GameObject instance;

    void Awake()
    {
        DontDestroy();
    }

    public void DontDestroy()
    {
        if (instance == null)
            instance = gameObject;
        else if (instance != gameObject)
            Destroy(gameObject);
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }
}