using UnityEngine;
using UnityEditor;
using System.IO;

public class Tools : MonoBehaviour
{
    [MenuItem("Tools/Clear Progress &c")]
    static void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Tools/Take Screenshot &s")]
    static void Screenshot()
    {
        ScreenCapture.CaptureScreenshot("Assets/Screenshot/screenshot.png");
    }

    [MenuItem("Tools/Get Unique Names")]
    static void GetUniqueNames()
    {
        foreach (var dontRespawnClass in FindObjectsOfType(typeof(DontRespawnOnLoad)) as DontRespawnOnLoad[])
        {
            var go = dontRespawnClass.gameObject;
            go.name = go.name + "(" + Path.GetRandomFileName() + ")";
        }
    }
}