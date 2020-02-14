/*****************************
 * Connor Wolf
 * Blessed.cs
 * Assignment 4
 * Blessed Enchantment
 *****************************/
using UnityEngine;

public class Blessed : EnchantmentDecorator
{
    public Blessed(Sword sword) : base(sword)
    {
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() + 5;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", blessed";
    }
}
