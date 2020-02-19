/*******************************
 * Author: Connor Wolf
 * File: PitchingMachine.cs
 * Date: 2/18/20
 * Description: Factory for pitches 
 ******************************/
using UnityEngine;

public class PitchingMachine : MonoBehaviour
{
    public static PitchingMachine instance;
    [SerializeField]
    private Ball[] ballTypes = new Ball[3];

    private void Awake()
    {
        instance = this;    
    }

    public Ball CreateBall()
    {
        //Debug.Log("Here it comes...");
        return ballTypes[Random.Range(0, ballTypes.Length)];
    }
}
