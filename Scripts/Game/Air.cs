using UnityEngine;

public class Air : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        SetAirJump(collision.gameObject,true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        SetAirJump(collision.gameObject, false);
    }

    void SetAirJump(GameObject go, bool airJump)
    {
        if (go == Player.player || go.CompareTag("Enemy"))
        {
            go.GetComponent<Character>().airJump = airJump;
        }
    }
}