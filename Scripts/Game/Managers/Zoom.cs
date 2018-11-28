using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float zoomAmount;
    public float maxZoom;

    public Transform toFollow;
    public float smoothTime;

    public Transform bat;
    public Transform finalBatPos;
    public float batSmoothTime;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
        if (PlayerPrefs.GetString("End") == "true")
        {
            enabled = true;
            MaxZoom();
        }
    }

    void Start()
    {
        GetComponent<Cam>().StopFollow();
        bat.SetParent(null);
        StartCoroutine(SmoothMovement.Follow(bat, finalBatPos, batSmoothTime));
        StartCoroutine(SmoothMovement.Follow(transform, toFollow, smoothTime));
        PlayerPrefs.SetString("End", "true");
    }

    void Update()
    {
        if (cam.orthographicSize < maxZoom)
            cam.orthographicSize += zoomAmount * Time.deltaTime;
        else
            MaxZoom();
    }

    void MaxZoom()
    {
        cam.orthographicSize = maxZoom;
    }
}