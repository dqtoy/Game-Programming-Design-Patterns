using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperPrime : MonoBehaviour
{
    public float flipperForce;
    public string triggerButton;
    public BumperGod bGod;
    public FlipperObserver myObserver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(triggerButton))
        {
            bGod.Switch(triggerButton);
            myObserver.Toggle(flipperForce);

            foreach (Collider col in Physics.OverlapSphere(transform.position, 1f))
            {
                if (col.gameObject.GetComponent<Rigidbody>() != null)
                {
                    Debug.Log("Blowing up " + col.gameObject.name.ToString());
                    col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(flipperForce, col.gameObject.transform.position + Vector3.down, 5);
                }
            }
        }
    }
}
