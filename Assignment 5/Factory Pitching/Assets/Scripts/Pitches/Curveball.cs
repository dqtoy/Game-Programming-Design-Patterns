/*******************************
 * Author: Connor Wolf
 * File: Curveball.cs
 * Date: 2/18/20
 * Description: Curveball class 
 ******************************/
using UnityEngine;

public class Curveball : Ball
{
    private void Awake()
    {
        speed = 7;
        curve = true;
        sink = false;
        targetKey = KeyCode.LeftArrow;
    }
}
