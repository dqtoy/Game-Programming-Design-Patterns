using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBounds : MonoBehaviour
{
    public Vector2 Hbounds;
    public Vector2 Vbounds;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > Hbounds.y) transform.Translate(Vector2.right * Hbounds.x * 2);
        if (transform.position.x < Hbounds.x) transform.Translate(Vector2.right * Hbounds.y * 2);

        if (Vbounds != Vector2.zero)
        {
            if (transform.position.y < Vbounds.x) transform.Translate(Vector2.up * Vbounds.y * 3);
        }
    }
}
