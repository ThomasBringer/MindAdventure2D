using System.Collections;
using UnityEngine;

public static class FadeInAndOut
{
    public static IEnumerator Fade(SpriteRenderer sprite, float time, bool show)
    {
        sprite.color = new Color(1, 1, 1, show ? 0 : 1);
        for (float i = 0; i <= 1; i += 1 / (time / Time.deltaTime))
        {
            sprite.color = new Color(1, 1, 1, show ? i : 1 - i);
            yield return null;
        }
        sprite.color = new Color(1, 1, 1, show ? 1 : 0);
    }

    public static IEnumerator Fade(SpriteRenderer sprite, float time)
    {
        bool show = sprite.color.a < 0.5f;
        sprite.color = new Color(1, 1, 1, show ? 0 : 1);
        for (float i = 0; i <= 1; i += 1 / (time / Time.deltaTime))
        {
            sprite.color = new Color(1, 1, 1, show ? i : 1 - i);
            yield return null;
        }
        sprite.color = new Color(1, 1, 1, show ? 1 : 0);
    }
}