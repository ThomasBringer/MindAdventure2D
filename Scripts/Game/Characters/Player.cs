using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public static GameObject player;
    public static Player playerClass;
    public static Rigidbody2D playerRb;

    public GameObject axe;

    bool throwing = false;

    public static void Checkpoint(Vector2 position,int count)
    {
        PlayerPrefs.SetFloat("XPos", position.x);
        PlayerPrefs.SetFloat("YPos", position.y);
        PlayerPrefs.SetInt("Count", count);
    }

    public static int GetCheckpointCount()
    {
        return PlayerPrefs.GetInt("Count");
    }

    static Vector2 GetPos()
    {
        return new Vector2(PlayerPrefs.GetFloat("XPos", 0), PlayerPrefs.GetFloat("YPos", 0));
    }

    protected override void Awake()
    {
        base.Awake();

        player = gameObject;
        playerClass = GetComponent<Player>();
        playerRb = rb;

        transform.position = GetPos();
    }

    protected override void Update()
    {
        base.Update();

        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Jump(1);

            if (Input.GetKeyDown(KeyCode.DownArrow))
                Crouch(true);
            if (Input.GetKeyUp(KeyCode.DownArrow))
                Crouch(false);

            if (Input.GetKeyDown(KeyCode.Space))
                Throw();

            if (!throwing)
            {
                Walk(Input.GetAxisRaw("Horizontal"));
            }
        }
    }

    void Throw()
    {
        if (grounded && !throwing)
        {
            throwing = true;
            anim.SetBool("Throwing", true);
        }
    }

    void ThrowAxe()
    {
        GameObject instance = Instantiate(axe, (Vector2)transform.position + transform.localScale * new Vector2(16.59444f, 2.891329f), Quaternion.Euler(new Vector3(0, 0, transform.localScale.x * -36.036f)));
        instance.transform.localScale = transform.localScale;
        instance.GetComponent<Translate>().speed *= transform.localScale;
        instance.GetComponent<Spin>().speed *= transform.localScale.x;

        throwing = false;
        anim.SetBool("Throwing", false);
    }

    public void Kill()
    {
        StartCoroutine(LongKill());
    }

    IEnumerator LongKill()
    {
        if (!dead)
        {
            base.Die(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}