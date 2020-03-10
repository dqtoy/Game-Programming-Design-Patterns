using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinShip : AbstractShip
{
    protected override Vector2 PrimitiveDirection()
    {
        if (dir == Vector2.up)
            dir = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y).normalized;
        else
        {
            dir += new Vector2(Mathf.Sin(Time.time*8)/10, 0);
        }
        
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
