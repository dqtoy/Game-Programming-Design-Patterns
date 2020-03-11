/* 
 * Connor Wolf
 * MoveCommand.cs
 * Assignment 7
 * Concrete Command Class for Move
 */
using UnityEngine;

public class MoveCommand : Command
{
    private MoveReceiver mover;

    public bool ExecuteCommand()
    {
        if (mover == null) mover = Object.FindObjectOfType<MoveReceiver>();
        return mover.Move();
    }

    //Pretty sure this isn't right
    public bool UndoCommand()
    {
        return ExecuteCommand();
    }
}
