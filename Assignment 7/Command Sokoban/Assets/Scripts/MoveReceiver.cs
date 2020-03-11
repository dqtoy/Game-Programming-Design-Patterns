/* 
 * Connor Wolf
 * MoveReceiver.cs
 * Assignment 7
 * Receiver class for movement
 */
using UnityEngine;

public class MoveReceiver : MonoBehaviour
{
    public bool Move()
    {
        char directionChar = PlayerInvoker.moveDir;
        Vector3 moveVector = Vector3.forward;
        bool undo = (directionChar == 'B');

        //Set the move vector.
        do
        {
            switch (directionChar)
            {
                case 'W':
                    moveVector = Vector2.up;
                    break;
                case 'A':
                    moveVector = Vector2.left;
                    break;
                case 'S':
                    moveVector = Vector2.down;
                    break;
                case 'D':
                    moveVector = Vector2.right;
                    break;
                case 'B':
                    if (PlayerInvoker.moveStack.Count == 0)
                    {
                        return false;
                    }
                    directionChar = PlayerInvoker.moveStack.Peek();
                    break;
            }
        } while (moveVector == Vector3.forward);

        //Try to move the player
        RaycastHit2D hit = Physics2D.Raycast(PlayerInvoker.player.position, moveVector, 1);
        if (hit.collider == null) PlayerInvoker.player.position += moveVector;
        else
        { //Pushing Boxes
            if (hit.collider.gameObject.layer == 8)
            {
                RaycastHit2D[] secondaryHits = Physics2D.RaycastAll(hit.collider.gameObject.transform.position, moveVector, 1);

                foreach (RaycastHit2D raycast in secondaryHits)
                {
                    if (raycast.collider.gameObject != hit.collider.gameObject)
                    {
                        return false;
                    }
                }

                PlayerInvoker.player.position += moveVector;
                hit.collider.gameObject.transform.position += moveVector;
            }
            else return false;
        }

        //Was there a box to undo?
        if (undo)
        {
            RaycastHit2D undoHit = Physics2D.Raycast(PlayerInvoker.player.position, moveVector * -1, 2);
            if (undoHit.collider != null)
            {
                if (undoHit.collider.gameObject.layer == 8)
                {
                    undoHit.collider.gameObject.transform.position += moveVector;
                }
            }
        }

        return true;
    }
}
