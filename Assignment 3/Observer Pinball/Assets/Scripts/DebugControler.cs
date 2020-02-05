/******************************************
 * Author Name: Connor Wolf
 * File Name: DebugControler.cs
 * Creation Date: 2/3/20 
 * Description: Debug Controls.
 ******************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugControler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }
}
