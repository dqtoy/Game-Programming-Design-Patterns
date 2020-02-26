using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affliction
{
    private string affliction;

    private int damage;

    public Affliction(int damageIn)
    {
        int temp = Random.Range(0, 4);
        switch (temp)
        {
            case 0:
                affliction = "Fire";
                break;
            case 1:
                affliction = "Water";
                    break;
            case 2:
                affliction = "Earth";
                break;
            case 3:
                affliction = "Air";
                break;
        }


        damage = damageIn;
    }

    public string GetAfflictionTitle()
    {
        switch (affliction)
        {
            case "Fire":
                if (damage == 1) { return "Frozem"; }
                else return "Frozen";
            case "Water":
                if (damage == 1) { return "Burred"; }
                else return "Burned";
            case "Earth":
                if (damage == 1) { return "ParaIized"; }
                else return "Paralyzed";
            case "Air":
                if (damage == 1) { return "Saoked"; }
                else return "Soaked";
        }
        return "DNF";
    }

    public string GetAfflicitonElement()
    {
        return affliction;
    }

    public int GetAfflictionDamage()
    {
        return damage;
    }
}
