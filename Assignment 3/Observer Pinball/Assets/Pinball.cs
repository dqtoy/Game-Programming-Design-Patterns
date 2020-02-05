using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

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
