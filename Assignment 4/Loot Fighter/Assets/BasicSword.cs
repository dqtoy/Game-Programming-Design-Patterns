/*****************************
 * Connor Wolf
 * BasicSword.cs
 * Assignment 4
 * Basic form of the Sword
 *****************************/
using UnityEngine;

public class BasicSword : Sword
{
    public string description = "A simple sword";
    public float baseDamage = 0;

    public string GetDescription()
    {
        return description;
    }

    public float GetDamage()
    {
        return baseDamage;
    }
}
