/******************************************
 * Author Name: Connor Wolf
 * File Name: FlipperPrime.cs
 * Creation Date: 2/3/20 
 * Description: Behaviour of the pinball flipper. Also sends data to observers.
 ******************************************/
using System.Collections.Generic;
using UnityEngine;

public class FlipperPrime : MonoBehaviour
{
    public float flipperForce;
    public string triggerButton;
    private float dir;

    public List<Observer> observers;

    public void AddObserver(Observer newOb)
    {
        observers.Add(newOb);
    }

    public void RemoveObserver(Observer trashOb)
    {
        observers.Remove(trashOb);
    }

    public void ToggleObservers()
    {
        foreach(Observer ob in observers)
        {
            ob.Toggle(dir);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (triggerButton == "Right")
            dir = 1; else dir = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(triggerButton))
        {

            ToggleObservers();

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
