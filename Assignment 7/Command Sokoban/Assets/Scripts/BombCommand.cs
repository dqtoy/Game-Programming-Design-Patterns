/* 
 * Connor Wolf
 * BombCommand.cs
 * Assignment 7
 * Concrete Command Class for Bomb
 */
using UnityEngine;

public class BombCommand : Command
{
    private BombReceiver bomber;

    public bool ExecuteCommand()
    {
        if (bomber == null) bomber = Object.FindObjectOfType<BombReceiver>();
        return bomber.Bomb();
    }

    public bool UndoCommand()
    {
        if (bomber != null) bomber = Object.FindObjectOfType<BombReceiver>();
        return bomber.Unbomb();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
