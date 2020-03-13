using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI shipsLeft;

    public static GameManager instance;

    private int numberOfShips;

    public static bool gameRunning;

    private void Awake()
    {
        gameRunning = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        if (gameRunning)
        {
            numberOfShips = Object.FindObjectsOfType<AbstractShip>().Length;
            shipsLeft.text = numberOfShips.ToString();
        }

        if (numberOfShips == 0)
        {
            shipsLeft.text = "You win! Press R to play again.";
        }
    }

    public void Lose()
    {
        gameRunning = false;
        shipsLeft.text = "You lose... Press R to try again.";
    }
}
