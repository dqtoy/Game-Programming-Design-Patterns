/*****************************
 * Connor Wolf
 * GameManager.cs
 * Assignment 2
 * Whack a mole game driver
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public int timer = 30;
    public static int score;

    public bool gameRunning = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!gameRunning)
            {
                gameRunning = true;
                InvokeRepeating("Countdown", 0, 1);
                score = 0;
                timer = 30;

                Hole[] holes = FindObjectsOfType<Hole>();

                foreach (Hole myHole in holes)
                {
                    myHole.TriggerMole();
                }
            }
        }

        if (gameRunning) scoreText.text = score.ToString();

        if (timer <= 0 && gameRunning)
        {
            CancelInvoke();
            gameRunning = false;

            Hole[] holes = FindObjectsOfType<Hole>();

            foreach (Hole myHole in holes)
            {
                myHole.EndGame();
            }
        }
    }

    void Countdown()
    {
        timer--;
        timerText.text = timer.ToString();
    }
}
