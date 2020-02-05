/*****************************
 * Connor Wolf
 * AntiBehaviour.cs
 * Assignment 2
 * Behaviour of a anti mole (interface)
 * ***************************/
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBehaviour : IMoleBehaviour
{
    public void Activate()
    {
        Debug.Log("Anti Mole: Activated.");
    }

    public void Whack()
    {
        Debug.Log("Anti Mole: Whacked!");
    }
}