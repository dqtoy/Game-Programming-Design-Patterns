/*******************************
 * Author: Connor Wolf
 * File: Sinker.cs
 * Date: 2/18/20
 * Description: Sinker class 
 ******************************/
using UnityEngine;

public class Sinker : Ball
{
    private void Awake()
    {
        speed = 10;
        curve = false;
        sink = true;
        targetKey = KeyCode.DownArrow;
        Invoke("Slow", 0.8f);
    }
    
    private void Slow()
    {
        speed = 4f;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
