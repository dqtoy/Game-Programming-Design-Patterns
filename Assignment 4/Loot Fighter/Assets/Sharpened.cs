using UnityEngine;

public class Sharpened : EnchantmentDecorator
{
    public Sharpened(Sword sword) : base(sword)
    {
        Debug.Log("Sharpening blade...");
    }

    public override float GetDamage()
    {
        return tempSword.GetDamage() + 1;
    }

    public override string GetDescription()
    {
        return tempSword.GetDescription() + ", sharpened";
    }
}
