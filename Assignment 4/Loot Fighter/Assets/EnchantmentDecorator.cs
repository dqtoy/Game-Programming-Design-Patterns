/*****************************
 * Connor Wolf
 * EnchantmentDecorator.cs
 * Assignment 4
 * Controls decoration of swords
 *****************************/
using UnityEngine;

public abstract class EnchantmentDecorator : Sword
{
    protected Sword tempSword;

    public EnchantmentDecorator(Sword sword)
    {
        tempSword = sword;
    }

    public abstract string GetDescription();

    public abstract float GetDamage();

    
    
}
