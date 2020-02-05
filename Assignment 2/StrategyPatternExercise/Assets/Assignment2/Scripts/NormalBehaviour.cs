/*****************************
 * Connor Wolf
 * NormalBehaviour.cs
 * Assignment 2
 * Behaviour of a normal mole (interface)
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBehaviour : IMoleBehaviour
{
    public void Activate()
    {
        Debug.Log("Normal Mole: Activated.");
    }

    public void Whack()
    {
        Debug.Log("Normal Mole: Whacked!");
    }
}
