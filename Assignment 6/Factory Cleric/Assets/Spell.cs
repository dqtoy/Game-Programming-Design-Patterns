using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    protected string element;
    protected int damage;

    public abstract void Cast();

    public Spell(string elementIn, int damageIn)
    {
        element = elementIn;
        damage = damageIn;
    }

    public string GetElement()
    {
        return element;
    }

    public int GetDamage()
    {
        return damage;
    }
}
