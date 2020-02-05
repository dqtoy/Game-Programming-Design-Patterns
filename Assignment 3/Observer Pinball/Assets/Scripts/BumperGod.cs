/******************************************
 * Author Name: Connor Wolf
 * File Name: BumperGod.cs
 * Creation Date: 2/3/20 
 * Description: Manager of all the bumpers.
 ******************************************/
using UnityEngine;

public class BumperGod : Observer
{
    public Bumper[] bumpers;
    

    public override void Toggle(float dir)
    {
        if (dir == 1)
            SwitchRight();
        else
            SwitchLeft();
    }

    private void SwitchLeft()
    {
        Debug.Log("ToggleLeft");
        foreach (Bumper bump in bumpers)
        {
            if (bump.lit)
            {
                if (!bump.leftBumper.lit)
                    bump.leftBumper.ToggleLit();
            }
            else
            {
                if (bump.leftBumper.lit)
                    bump.leftBumper.ToggleLit();
            }
        }
    }

    private void SwitchRight()
    {
        Debug.Log("ToggleRight");
        foreach (Bumper bump in bumpers)
        {
            {
                if (bump.lit)
                {
                    if (!bump.rightBumper.lit)
                        bump.rightBumper.ToggleLit();
                } else
                {
                    if (bump.rightBumper.lit)
                        bump.rightBumper.ToggleLit();
                }
            }
        }
    }
}
