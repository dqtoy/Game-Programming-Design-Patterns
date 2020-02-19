/*******************************
 * Author: Connor Wolf
 * File: BattingPractice.cs
 * Date: 2/18/20
 * Description: Driver for Game 
 ******************************/
using UnityEngine;

public class BattingPractice : MonoBehaviour
{
    public GameObject baseballPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PitchBall();
        }
    }

    void PitchBall()
    {
                Debug.Log("Pitching Ball...");
        GameObject curBall = Instantiate(baseballPrefab, transform.position, Quaternion.identity);
        System.Type curType = PitchingMachine.instance.CreateBall().GetType();
                Debug.Log("It's a " + curType.ToString() + "!");
        curBall.AddComponent(curType);
    }
}
