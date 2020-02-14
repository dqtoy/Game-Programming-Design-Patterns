/*****************************
 * Connor Wolf
 * Rusted.cs
 * Assignment 4
 * Burning Enchantment
 *****************************/
using UnityEngine;

public class Rusted : EnchantmentDecorator
{
    public Rusted(Sword sword) : base(sword)
    {
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() - 2;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", rusted";
    }
}
