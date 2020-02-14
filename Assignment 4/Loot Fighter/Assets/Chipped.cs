/*****************************
 * Connor Wolf
 * Chipped.cs
 * Assignment 4
 * Chipped Enchantment
 *****************************/
using UnityEngine;

public class Chipped : EnchantmentDecorator
{
    public Chipped(Sword sword) : base(sword)
    {
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() - 1;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", chipped";
    }
}
