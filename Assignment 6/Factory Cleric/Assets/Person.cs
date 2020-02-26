using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    private Queue<Affliction> afflictions = new Queue<Affliction>();

    public Person(int numberOfAfflictions)
    {
        int tempDamage = (int)Mathf.Sign(Random.Range(-1f, 1f));
        for (int i = 0; i != numberOfAfflictions; i++)
        {
            afflictions.Enqueue(new Affliction(tempDamage));
        }
    }

    public string GetDescription()
    {
        string returnString = "";
        Affliction[] tempAfflictions = afflictions.ToArray();
        for (int i = 0; i != tempAfflictions.Length; i++)
        {
            returnString += tempAfflictions[i].GetAfflictionTitle() + ", ";
        }
        return returnString;
    }

    public bool CompareAffliction(Spell spell)
    {
        Affliction curAffliction = afflictions.Peek();

        if (curAffliction.GetAfflicitonElement() == spell.GetElement())
        {
            if (curAffliction.GetAfflictionDamage() == spell.GetDamage())
            {
                //This is the correct spell.
                afflictions.Dequeue();
                return true;
            } else
            return false;
        } else
        return false;
    }

}
