/******************************************
 * Author Name: Connor Wolf
 * File Name: FlipperObserver.cs
 * Creation Date: 2/3/20 
 * Description: Behaviour of the flipper observer.
 ******************************************/
using UnityEngine;

public class FlipperObserver : Observer
{
    public override void Toggle(float flipperForce)
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, 1f))
        {
            if (col.gameObject.GetComponent<Rigidbody>() != null)
            {
                Debug.Log("Blowing up " + col.gameObject.name.ToString());
                col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, col.gameObject.transform.position + Vector3.down, 5);
            }
        }
    }
}
