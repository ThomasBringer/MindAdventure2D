using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    public enum Behavior { Idles, KeepsWalking, Jumps, TurnsBack, Waits, WaitsAndCrouchs, FollowsPlayer, FollowsPlayerAndJumps, Random };
    public Behavior behavior;
    public int originalDirection;

    int direction;
    bool decided = false;

    DontRespawnOnLoad dontRespawnClass;

    protected override void Awake()
    {
        base.Awake();
        dontRespawnClass = GetComponent<DontRespawnOnLoad>();
    }

    void Start()
    {
        ResetDirection();
        transform.localScale = new Vector2(direction, 1);
    }

    protected override void Update()
    {
        base.Update();

        if (!dead)
        {
            bool futureGrounded = Physics2D.OverlapArea(new Vector2(boxCollider.size.x * transform.localScale.x + transform.position.x - boxCollider.size.x / 2 + 0.5f, transform.position.y - boxCollider.size.y / 2 + boxCollider.offset.y - 2), new Vector2(boxCollider.size.x * transform.localScale.x + transform.position.x + boxCollider.size.x / 2 - 0.5f, transform.position.y - boxCollider.size.y / 2 + boxCollider.offset.y), environment);
            Vector2 distance = GetDistanceToPlayer();

            switch (behavior)
            {
                case Behavior.Idles:
                    direction = 0;
                    WalkInDirection();
                    break;

                case Behavior.KeepsWalking:
                    WalkInDirection();
                    break;

                case Behavior.Jumps:
                    if (!futureGrounded)
                        JumpIfGrounded();
                    WalkInDirection();
                    break;

                case Behavior.TurnsBack:
                    if (grounded && !futureGrounded)
                        direction = -direction;
                    WalkInDirection();
                    break;

                case Behavior.Waits:
                    direction = futureGrounded ? (int)transform.localScale.x : 0;
                    WalkInDirection();
                    break;

                case Behavior.WaitsAndCrouchs:
                    direction = futureGrounded ? (int)transform.localScale.x : 0;
                    WalkInDirection();
                    Crouch(!futureGrounded);
                    break;

                case Behavior.FollowsPlayer:
                    direction = Mathf.Abs(distance.x) < 1 ? 0 : (int)Mathf.Sign(distance.x);
                    if (distance.y > 0)
                        JumpIfGrounded();
                    WalkInDirection();
                    break;

                case Behavior.FollowsPlayerAndJumps:
                    direction = Mathf.Abs(distance.x) < 1 ? 0 : (int)Mathf.Sign(distance.x);
                    if (distance.y > 0 || !futureGrounded)
                        JumpIfGrounded();
                    WalkInDirection();
                    break;

                case Behavior.Random:
                    if (grounded && !futureGrounded)
                    {
                        if (!decided)
                        {
                            switch (Random.Range(0, 4))
                            {
                                case 1:
                                    Jump(1);
                                    break;
                                case 2:
                                    direction = -direction;
                                    break;
                                case 3:
                                    direction = 0;
                                    break;
                            }
                            decided = true;
                        }
                    }
                    else
                    {
                        direction = (int)transform.localScale.x;
                        decided = false;
                    }
                    WalkInDirection();
                    break;
            }
        }
    }

    void JumpIfGrounded()
    {
        if (grounded)
            Jump(1);
    }

    Vector2 GetDistanceToPlayer()
    {
        return Player.player.transform.position - transform.position;
    }

    void WalkInDirection()
    {
        Walk(direction);
    }

    public void ResetDirection()
    {
        direction = originalDirection;
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
            dontRespawnClass.DontRespawn();
            Destroy(GetComponent<KillerOnCollision>());
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
        }
    }
}