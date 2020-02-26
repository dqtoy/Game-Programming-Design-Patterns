using UnityEngine;
using System.Collections;

public class HealSpell : Spell
{
    public HealSpell(string elementInput, int damageInput) : base (elementInput, damageInput)
    { }

    public override void Cast()
    {
        Debug.Log("Healing using " + element + "!");
    }
}
