/******************************************
 * Author Name: Connor Wolf
 * File Name: Reset.cs
 * Creation Date: 2/3/20 
 * Description: Resets the ball on a failure.
 ******************************************/
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respawnPoint.position;
        }
    }
}
