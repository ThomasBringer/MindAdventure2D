using UnityEngine;

public class DontRespawnOnLoad : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetString(gameObject.name) == "true")
        {
            gameObject.SetActive(false);
        }
    }

    public void DontRespawn()
    {
        PlayerPrefs.SetString(gameObject.name, "true");
    }
}