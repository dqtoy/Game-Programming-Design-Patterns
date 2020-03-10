using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShip : MonoBehaviour
{
    protected Transform player;
    protected Vector2 dir = Vector2.up;
    private bool dropping;

    protected void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        Invoke("ToggleDrop", Random.Range(5, 30));
    }

    private void ToggleDrop()
    {
        dropping = true;
    }

    protected virtual void Drop()
    {
        if (GameManager.gameRunning)
        {
            if (dropping)
                TemplateDrop();
        }
    }

    public void TemplateDrop()
    {
        transform.Translate(PrimitiveDirection() * PrimitiveSpeed());
    }

    protected abstract float PrimitiveSpeed();
    protected abstract Vector2 PrimitiveDirection();

    protected void CheckDeath(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(player.gameObject.GetComponent<PlayerController>().explosion, transform.position, Quaternion.identity);
        }
    }
}
