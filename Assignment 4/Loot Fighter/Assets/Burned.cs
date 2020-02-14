/*****************************
 * Connor Wolf
 * Burned.cs
 * Assignment 4
 * Burning Enchantment
 *****************************/
using UnityEngine;

public class Burned : EnchantmentDecorator
{
    public Burned(Sword sword) : base(sword)
    {
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() + 2;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", blazing";
    }
}
