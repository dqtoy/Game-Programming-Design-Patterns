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

    public Ball CreateBall(string ballType)
    {
        int ballIndex = -1;
        switch (ballType)
        {
            case "Fastball":
                ballIndex = 1;
                break;

            case "Curveball":
                ballIndex = 0;
                break;

            case "Changeup":
                ballIndex = 2;
                break;

            case "Random":
                ballIndex = Random.Range(0, 3);
                break;
        }
        return ballTypes[ballIndex];
    }
}
