using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{

    [Range(0,5000)]
    public float launchSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

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
