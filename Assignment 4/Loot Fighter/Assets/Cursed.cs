/*****************************
 * Connor Wolf
 * Cursed.cs
 * Assignment 4
 * Cursed Enchantment
 *****************************/
using UnityEngine;

public class Cursed : EnchantmentDecorator
{
    public Cursed(Sword sword) : base(sword)
    {
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() - 5;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", cursed";
    }
}
