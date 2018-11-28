using System.Collections;
using UnityEngine;

public class SwitchRepeatedly : SwitchBehaviorAndGameObject
{
    public float time;

    void Start()
    {
        StartCoroutine(StepSwitch());
    }

    IEnumerator StepSwitch()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(time);
            SwitchAll(false);
        }
    }
}