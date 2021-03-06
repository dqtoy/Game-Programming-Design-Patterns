﻿/*****************************
 * Connor Wolf
 * Sharpened.cs
 * Assignment 4
 * Sharpened Enchantment
 *****************************/
using UnityEngine;

public class Sharpened : EnchantmentDecorator
{
    public Sharpened(Sword sword) : base(sword)
    {
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() + 3;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", sharpened";
    }
}
