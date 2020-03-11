using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopShip : AbstractShip
{
    private int loop;

    private void Start()
    {
        base.Start();
        loop = 4;
    }

    protected override Vector2 PrimitiveDirection()
    {
        if (dir == Vector2.up)
            dir = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y).normalized;

        transform.Rotate(Vector3.forward* loop);

        return dir;
    }

    protected override float PrimitiveSpeed()
    {
        return -0.1f;
    }

    // Update is called once per frame
    private void Update()
    {
        base.Drop();
        if (dir != Vector2.up)
            Invoke("StopLoop", Random.Range(1.5f, 2f));
    }

    private void StopLoop()
    {
        loop = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckDeath(collision);
    }
}
