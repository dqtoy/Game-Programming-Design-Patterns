/*****************************
 * Connor Wolf
 * Hole.cs
 * Assignment 2
 * Hole behaviour
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private float timeBetweenMoles;
    public Vector2 timeBetweenMolesRange;
    private GameObject myMole;

    private void Awake()
    {
        myMole = GetComponentInChildren<CapsuleCollider>().gameObject;
    }

    public void TriggerMole()
    {
        TriggerMole(Random.Range(timeBetweenMolesRange.x, timeBetweenMolesRange.y));
    }

    public void EndGame()
    {
        CancelInvoke();
        Destroy(myMole.GetComponent<Mole>());
        myMole.transform.position = transform.position + Vector3.down * 2;
    }

    private void TriggerMole(float timeToMole)
    {
        Invoke("NewMoleBehaviour", timeToMole);
    }

    private void NewMoleBehaviour()
    {
        Destroy(myMole.GetComponent<Mole>());
        int randomizer = Random.Range(0, 4);
        switch (randomizer)
        {
            case 0:
                myMole.AddComponent<NormalMole>();
                break;
            case 1:
                myMole.AddComponent<AntiMole>();
                break;
            case 2:
                myMole.AddComponent<SlowMole>();
                break;
            case 3:
                myMole.AddComponent<FastMole>();
                break;
        }
    }
}
