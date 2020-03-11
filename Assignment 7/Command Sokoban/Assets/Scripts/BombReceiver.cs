/* 
 * Connor Wolf
 * BombReceiver.cs
 * Assignment 7
 * Receiver class for bombs
 */
using UnityEngine;

public class BombReceiver : MonoBehaviour
{
    public bool Bomb()
    {
        if (Physics2D.CircleCastAll(PlayerInvoker.player.position, 1, Vector3.forward).Length == 0) return false;
        else
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(PlayerInvoker.player.position, 1, Vector3.forward);
            GameObject[] targets = new GameObject[8];
            int i = 0;
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.layer == 9)
                {
                    targets[i] = hit.collider.gameObject;
                    hit.collider.gameObject.SetActive(false);
                    i++;
                }
            }

            PlayerInvoker.bombStack.Push(targets);
            return true;
        }
    }

    public bool Unbomb()
    {
        if (PlayerInvoker.bombStack.Count == 0) return false;
        GameObject[] gameObjects = PlayerInvoker.bombStack.Peek();

        foreach (GameObject gm in gameObjects)
        {
            if (gm != null) gm.SetActive(true);
        }

        RaycastHit2D hit = Physics2D.Raycast(PlayerInvoker.player.position, Vector2.up, 0.1f);
        if (hit.collider == null) return true;

        foreach (GameObject gm in gameObjects)
        {
            if (gm != null) gm.SetActive(false);
        }

        return false;
    }
}
