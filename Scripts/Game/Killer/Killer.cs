using UnityEngine;

public class Killer : MonoBehaviour
{
    public bool deactivate;

    public bool killPlayer;
    public bool killEnemy;
    public bool killAxe;

    protected bool KillGo(GameObject go)
    {
        bool killed = false;

        if (killPlayer && go == Player.player)
        {
            if (!Player.playerClass.dead)
                Player.playerClass.Kill();
            killed = true;
        }
        if (killEnemy && go.CompareTag("Enemy"))
        {
            go.GetComponent<Enemy>().Kill();
            killed = true;
        }
        if (killAxe && go.CompareTag("Axe"))
        {
            Destroy(go);
            killed = true;
        }

        if (killed)
        {
            if (deactivate)
                gameObject.SetActive(false);
        }
        return killed;
    }
}