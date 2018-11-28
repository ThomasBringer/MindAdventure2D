using UnityEngine;

public class Respawner : Killer
{
    static GameObject[] gameObjects;
    static Vector2[] positions;
    static Quaternion[] rotations;

    public static Respawner respawnerClass;

    void Start()
    {
        respawnerClass = GetComponent<Respawner>();

        gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];

        positions = new Vector2[gameObjects.Length];
        rotations = new Quaternion[gameObjects.Length];

        int i = 0;
        foreach (GameObject go in gameObjects)
        {
            positions[i] = go.transform.position;
            rotations[i] = go.transform.rotation;
            i++;
        }
    }

    public void Respawn(GameObject goToRespawn)
    {
        if (!KillGo(goToRespawn))
        {
            int i = 0;
            foreach (GameObject go in gameObjects)
            {
                if (go != null)
                {
                    if (go == goToRespawn)
                    {
                        go.transform.position = positions[i];
                        go.transform.rotation = rotations[i];

                        var goRb = go.GetComponent<Rigidbody2D>();
                        if (goRb != null)
                        {
                            goRb.bodyType = RigidbodyType2D.Kinematic;
                            goRb.velocity = Vector2.zero;
                        }
                        var goEnemy = go.GetComponent<Enemy>();
                        if (goEnemy != null)
                        {
                            goEnemy.ResetDirection();
                        }
                    }
                    i++;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Respawn(collision.gameObject);
    }
}