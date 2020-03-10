using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject explosion;

    public float moveSpeed;

    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void Move()
    {
        float hMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * hMove * moveSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("PlayerBullet"))
        {
            GameManager.instance.Lose();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
