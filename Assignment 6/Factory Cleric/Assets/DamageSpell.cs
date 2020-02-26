using UnityEngine;
using System.Collections;

public class DamageSpell : Spell
{
    public DamageSpell(string elementInput, int damageInput) : base(elementInput, damageInput)
    { }

    public override void Cast()
    {
        Debug.Log("Fighting using " + element +"!");
    }
}
