/* 
 * Connor Wolf
 * ClientLogic.cs
 * Assignment 7
 * Client class that runs logic
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientLogic
{
    public char CheckMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            return 'W';
        } else
        if (Input.GetKeyDown(KeyCode.A))
        {
            return 'A';
        } else
        if (Input.GetKeyDown(KeyCode.S))
        {
            return 'S';
        } else
        if (Input.GetKeyDown(KeyCode.D))
        {
            return 'D';
        } else
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            return 'B';
        }

        return ' ';
    }

    public char CheckBomb()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            return 'B';
        } else
        if (Input.GetKeyDown(KeyCode.Return))
        {
            return 'U';
        }

        return ' ';
    }
}
