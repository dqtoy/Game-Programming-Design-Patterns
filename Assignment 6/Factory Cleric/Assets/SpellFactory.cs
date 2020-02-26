using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellFactory
{
    protected Queue<Spell> spellQueue = new Queue<Spell>();
    protected Spell settingSpell;

    public void CastSpells()
    {
        while (spellQueue.Count > 0)
        {
            settingSpell = spellQueue.Dequeue();
            settingSpell.Cast();
            GameManager.instance.NewAttack(settingSpell);
        }
    }

    public void DeleteLastSpell()
    {
        if (spellQueue.Count > 0)
        {
            spellQueue.Dequeue();
        }
    }

    public string GetSpells()
    {
        string returnString = "";
        Spell[] tempSpells = spellQueue.ToArray();
        for (int i = 0; i != tempSpells.Length; i++)
        {
            returnString += tempSpells[i].GetElement() + ", ";
        }
        return returnString;
    }

    public abstract void NewSpell(string element);
}
