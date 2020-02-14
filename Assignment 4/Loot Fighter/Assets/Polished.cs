/*****************************
 * Connor Wolf
 * Polished.cs
 * Assignment 4
 * Polished Enchantment
 *****************************/
using UnityEngine;

public class Polished : EnchantmentDecorator
{
    public Polished(Sword sword) : base(sword)
    {
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() + 1;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", polished";
    }
}
