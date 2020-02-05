/*****************************
 * Connor Wolf
 * FastBehaviour.cs
 * Assignment 2
 * Behaviour of a fast mole (interface)
 * ***************************/
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBehaviour : IMoleBehaviour
{
    public void Activate()
    {
        Debug.Log("Fast Mole: Activated.");
    }

    public void Whack()
    {
        Debug.Log("Fast Mole: Whacked!");
    }
}

