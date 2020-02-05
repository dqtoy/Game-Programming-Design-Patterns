/*****************************
 * Connor Wolf
 * SlowBehaviour.cs
 * Assignment 2
 * Behaviour of a slow mole (interface)
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBehaviour : IMoleBehaviour
{
    public void Activate()
    {
        Debug.Log("Slow Mole: Activated.");
    }

    public void Whack()
    {
        Debug.Log("Slow Mole: Whacked!");
    }
}
