/*******************************
 * Author: Connor Wolf
 * File: Fastball.cs
 * Date: 2/18/20
 * Description: Fastball class 
 ******************************/
using UnityEngine;

public class Fastball : Ball
{
    private void Awake()
    {
        speed = 15;
        curve = false;
        sink = false;
        targetKey = KeyCode.UpArrow;
    }

}
