using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFactory : SpellFactory
{
    public override void NewSpell(string element)
    {
        settingSpell = new DamageSpell(element, 1);
        spellQueue.Enqueue(settingSpell);
    }
}
