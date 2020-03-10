using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeShip : AbstractShip
{
    protected override Vector2 PrimitiveDirection()
    {
        if (dir == Vector2.up)
            dir = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y).normalized;

        return dir;
    }

    protected override float PrimitiveSpeed()
    {
        return -0.1f;
    }

    private void Update()
    {
        base.Drop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckDeath(other);
    }
}
