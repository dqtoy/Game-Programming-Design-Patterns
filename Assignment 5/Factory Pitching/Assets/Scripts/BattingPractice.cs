/*******************************
 * Author: Connor Wolf
 * File: BattingPractice.cs
 * Date: 2/18/20
 * Description: Driver for Game 
 ******************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattingPractice : MonoBehaviour
{
    public GameObject baseballPrefab;
    public TextMeshProUGUI leftPitch;
    public TextMeshProUGUI rightPitch;
    public TextMeshProUGUI strikeText;

    public TextMeshProUGUI goalText;

    public int goalHits = 5;

    public int curHits = 0;

    public int strikeCount = 0;

    public static BattingPractice instance;

    private string leftChoice;
    private string rightChoice;

    public string[] vs;

    private bool choosingPitch;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (strikeCount != 3 && curHits != goalHits)
        {
            goalText.text = curHits + " / " + goalHits;
            strikeText.text = strikeCount.ToString();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                choosingPitch = true;
                ChoosePitch();
            }

            if (choosingPitch)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    PitchBall(leftChoice);
                    choosingPitch = false;
                    leftPitch.text = "Here it comes!";
                    rightPitch.text = "Here it comes!";
                }
                else
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    PitchBall(rightChoice);
                    choosingPitch = false;
                    leftPitch.text = "Here it comes!";
                    rightPitch.text = "Here it comes!";
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }

    void ChoosePitch()
    {
        leftChoice = vs[Random.Range(0, vs.Length)];
        rightChoice = vs[Random.Range(0, vs.Length)];

        leftPitch.text = leftChoice;
        rightPitch.text = rightChoice;
    }

    void PitchBall()
    {
        GameObject curBall = Instantiate(baseballPrefab, transform.position, Quaternion.identity);
        System.Type curType = PitchingMachine.instance.CreateBall().GetType();
        curBall.AddComponent(curType);
    }

    void PitchBall(string ballType)
    {
        GameObject curBall = Instantiate(baseballPrefab, transform.position, Quaternion.identity);
        System.Type curType = GetType();
        curType = PitchingMachine.instance.CreateBall(ballType).GetType();
        curBall.AddComponent(curType);
    }

    public void CallHit()
    {
        curHits++;
        if (curHits == goalHits)
        {
            goalText.text = "You win! Press R to play again!";
        }
    }

    public void CallStrike()
    {
        strikeCount++;
        if (strikeCount == 3)
        {
            goalText.text = "You lose... Press R to restart.";
            strikeText.text = strikeCount.ToString();
        }
    }
}
