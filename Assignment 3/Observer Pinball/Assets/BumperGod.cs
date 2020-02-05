using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperGod : MonoBehaviour
{
    public Bumper[] bumpers;

    public void Switch(string dir)
    {
        if (dir == "Right")
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
