using UnityEngine;

public class Cam : MonoBehaviour
{
    public float smoothTime;
    Coroutine followPlayer;

    void Start()
    {
        transform.position = new Vector2(PlayerPrefs.GetFloat("CamX", 0), PlayerPrefs.GetFloat("CamY", 0));
        followPlayer = StartCoroutine(SmoothMovement.Follow(transform, Player.player.transform, smoothTime, false, true));
    }

    public void StopFollow()
    {
        StopCoroutine(followPlayer);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("CamX", transform.position.x);
        PlayerPrefs.SetFloat("CamY", transform.position.y);
    }
}