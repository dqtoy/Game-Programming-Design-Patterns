/*****************************
 * Connor Wolf
 * Mole.cs
 * Assignment 2
 * Mole superclass
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mole : MonoBehaviour
{
    public IMoleBehaviour MoleBehaviour { get; set; }

    public int scoreBonus;
    public float moleSpeed;
    public float moleStandbyTime;
    public int rising = 0;

    public virtual void DoActivate() { MoleBehaviour.Activate(); }
    public virtual void DoWhack() { MoleBehaviour.Whack(); }

    public virtual void DoOnMouseDown()
    {
        DoWhack();
        GameManager.score += scoreBonus;
        Debug.Log("Score: " + GameManager.score);
        transform.parent.GetComponent<Hole>().TriggerMole();
        rising = -2;
    }

    public virtual void DoUpdate()
    {
        if (rising == 1)
        {
            transform.Translate(Vector3.up * moleSpeed * Time.deltaTime);
            if (transform.position.y > 0)
            {
                rising = 0;
                Invoke("DoFall", moleStandbyTime);
            }
        }
        else
        if (rising < 0)
        {
            transform.Translate(Vector3.down * moleSpeed * Time.deltaTime);
            if (transform.position.y < -1)
            {
                if (rising == -1) transform.parent.GetComponent<Hole>().TriggerMole();
                Destroy(this);
            }
        }
    }

    public virtual void DoFall()
    {
        rising = -1;
    }
}
