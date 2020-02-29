using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFactory : SpellFactory
{
    public override void NewSpell(string element)
    {
        switch (element)
        {
            case ("Fire"):
                settingSpell = new DamageSpell("Fire", -1);
                break;
            case ("Water"):
                settingSpell = new DamageSpell("Water", -1);
                break;
            case ("Earth"):
                settingSpell = new DamageSpell("Earth", -1);
                break;
            case ("Air"):
                settingSpell = new DamageSpell("Air", -1);
                break;

        }
        spellQueue.Enqueue(settingSpell);
    }
}
