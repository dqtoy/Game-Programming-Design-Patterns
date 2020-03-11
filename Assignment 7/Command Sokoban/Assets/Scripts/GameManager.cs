using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] puzzles;
    private int curPuzzle;

    private List<GoalScript> goalScripts = new List<GoalScript>();

    private void Awake()
    {
        instance = this;
        curPuzzle = -1;
        NextPuzzle();
    }

    public void NextPuzzle()
    {
        if (curPuzzle != -1)
        {
            puzzles[curPuzzle].SetActive(false);
            goalScripts.Clear();
        }

        curPuzzle++;
        if (curPuzzle > puzzles.Length - 1)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        puzzles[curPuzzle].SetActive(true);
        
        foreach (GoalScript gs in GameObject.FindObjectsOfType<GoalScript>())
        {
            goalScripts.Add(gs);
        }
    }

    public void GiveUp()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (goalScripts.Capacity != 0)
        {
            if (ClearLevel()) NextPuzzle();
        }
    }

    bool ClearLevel()
    {
        foreach (GoalScript gs in goalScripts)
        {
            if (!gs.advance) return false;
        }

        return true;
    }
}
