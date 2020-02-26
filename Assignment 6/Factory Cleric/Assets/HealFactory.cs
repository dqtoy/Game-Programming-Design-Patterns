using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFactory : SpellFactory
{
    public override void NewSpell(string element)
    {
        settingSpell = new HealSpell(element, -1);
        spellQueue.Enqueue(settingSpell);
    }
}
