using TMPro;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            numberOfShips = Object.FindObjectsOfType<AbstractShip>().Length;
            shipsLeft.text = numberOfShips.ToString();
        }

        if (numberOfShips == 0)
        {
            shipsLeft.text = "You win!";
        }
    }

    public void Lose()
    {
        gameRunning = false;
        shipsLeft.text = "You lose...";
    }
}
