/******************************************
 * Author Name: Connor Wolf
 * File Name: Plunger.cs
 * Creation Date: 2/3/20 
 * Description: Behaviour of the pinball plunger.
 ******************************************/ 
using UnityEngine;

public class Plunger : MonoBehaviour
{
    [Range(0,5000)]
    public float launchSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            foreach (Collider col in Physics.OverlapSphere(transform.position, 1f))
            {
                if (col.gameObject.GetComponent<Rigidbody>() != null)
                {
                    Debug.Log("Blowing up " + col.gameObject.name.ToString());
                    col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(launchSpeed, col.gameObject.transform.position + Vector3.down, 5);
                }
            }
        }
    }
}
