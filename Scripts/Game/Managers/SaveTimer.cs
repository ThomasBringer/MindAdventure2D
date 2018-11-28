using UnityEngine;

public class SaveTimer : MonoBehaviour
{
    public float savedTimer;

    void OnEnable()
    {
        SaveTime();
    }

    public void SaveTime()
    {
        savedTimer = Time.time;
    }
}