using UnityEngine;

public class Quit : MonoBehaviour
{
    void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
#endif
    }
}