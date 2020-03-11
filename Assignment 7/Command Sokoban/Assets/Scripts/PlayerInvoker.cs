/* 
 * Connor Wolf
 * PlayerInvoker.cs
 * Assignment 7
 * Invoker class for the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoker : MonoBehaviour
{
    public static Stack<char> moveStack = new Stack<char>();
    public static Stack<GameObject[]> bombStack = new Stack<GameObject[]>();
    public static Transform player;

    private BombCommand bombCommand;
    private MoveCommand moveCommand;
    private ClientLogic client;

    [HideInInspector]
    public static char moveDir;

    [HideInInspector]
    public static char bomb;

    void Start()
    {
        bombCommand = new BombCommand();
        moveCommand = new MoveCommand();
        client = new ClientLogic();
        player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = client.CheckMove();
        bomb = client.CheckBomb();

        //Is there a move direction?
        if (moveDir != ' ')
        {
            //Is the move direction "Back"
            if (moveDir == 'B')
            {
                //Is there stuff in the stack to undo? Undo it and pop.
                if (moveCommand.UndoCommand())
                {
                    moveStack.Pop();
                }
            } else
            //Can the player move in that direction? Move and push.
            if (moveCommand.ExecuteCommand())
            {
                //Flip the direction for the undoing, might be in the wrong spot for the pattern
                switch (moveDir)
                {
                    case 'W':
                        moveDir = 'S';
                        break;
                    case 'A':
                        moveDir = 'D';
                        break;
                    case 'S':
                        moveDir = 'W';
                        break;
                    case 'D':
                        moveDir = 'A';
                        break;
                }

                moveStack.Push(moveDir);
            }
        }

        //Do you want a bomb command?
        if (bomb != ' ')
        {
            //Are you undoing a bomb? Can you?
            if (bomb == 'U')
            {
                if (bombCommand.UndoCommand())
                {
                    bombStack.Pop();
                }
            }
            else
                //BOOM!
                bombCommand.ExecuteCommand();
        }
    }
}
