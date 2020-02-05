/******************************************
 * Author Name: Connor Wolf
 * File Name: Pinball.cs
 * Creation Date: 2/3/20 
 * Description: Behaviour of the pinball ball.
 ******************************************/
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public static void Launch(Vector3 origin)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Pinball>().BallLaunch(origin);
    }

    private void BallLaunch(Vector3 origin)
    {
        GetComponent<Rigidbody>().AddExplosionForce(
            2500,
            transform.position-Vector3.down,
            1000
            );
    }
}
