using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
