using UnityEngine;

public class SwitchBehaviorAndGameObject : MonoBehaviour
{
    public Behaviour[] behaviors;
    public bool wholeGo;

    protected bool[] original;

    void Awake()
    {
        original = new bool[behaviors.Length];
        int i = 0;
        foreach (Behaviour behavior in behaviors)
        {
            original[i] = wholeGo ? GetSwitch(behavior.gameObject) : GetSwitch(behavior);
            i++;
        }
    }

    protected void SwitchAll(bool cantCancel)
    {
        int i = 0;
        foreach (Behaviour behavior in behaviors)
        {
            if (cantCancel)
            {
                if (wholeGo)
                    Switch(behavior.gameObject, !original[i]);
                else
                    Switch(behavior, !original[i]);
            }
            else
            {
                if (wholeGo)
                    SwitchToInverse(behavior.gameObject);
                else
                    SwitchToInverse(behavior);
            }
            i++;
        }
    }

    void SwitchToInverse(Behaviour behavior)
    {
        Switch(behavior, !GetSwitch(behavior));
    }

    void SwitchToInverse(GameObject go)
    {
        Switch(go, !GetSwitch(go));
    }

    void Switch(Behaviour behavior, bool enable)
    {
        behavior.enabled = enable;
    }

    void Switch(GameObject go, bool active)
    {
        go.SetActive(active);
    }

    bool GetSwitch(Behaviour behavior)
    {
        return behavior.enabled;
    }

    bool GetSwitch(GameObject go)
    {
        return go.activeSelf;
    }
}