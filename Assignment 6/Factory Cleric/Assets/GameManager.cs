using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Person curPerson;
    public Vector2 afflictionRange;

    private int strikeCount = 0;

    private SpellFactory curFactory;
    private int spellDamage = -1;

    public TextMeshProUGUI characterDescriptionText;
    public TextMeshProUGUI spellQueueText;
    public Image spellQueueBox;

    public Image timeLeftImage;
    public float timeToWin;
    private float timeRemaining;

    public TextMeshProUGUI personsRemainingText;
    public int personsRemaining;

    public GameObject tutorialBox;
    public TextMeshProUGUI tutorialText;

    private bool gameRunning;

    private void Awake()
    {
        instance = this;
        timeRemaining = timeToWin;
    }

    // Use this for initialization
    void Start()
    {
        curFactory = new HealFactory();
        spellDamage = -1;
        spellQueueBox.color = new Color(1, 1, 0);
        spellQueueText.text = "";
        personsRemainingText.text = personsRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        //Switch between Damage/Heal Factory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (spellDamage == 1)
            {
                spellDamage = -1;
                curFactory = new HealFactory();
                spellQueueBox.color = new Color(1, 1, 0);
            } else
            {
                spellDamage = 1;
                curFactory = new DamageFactory();
                spellQueueBox.color = new Color(1, 0, 0);
            }
        }

        //Queue spells
        if (Input.GetKeyDown(KeyCode.Q))
        {
            curFactory.NewSpell("Fire");
        } else
        if (Input.GetKeyDown(KeyCode.W))
        {
            curFactory.NewSpell("Water");
        } else
        if (Input.GetKeyDown(KeyCode.E))
        {
            curFactory.NewSpell("Earth");
        } else
        if (Input.GetKeyDown(KeyCode.R))
        {
            curFactory.NewSpell("Air");
        }

        //Delete Last Spell
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            curFactory.DeleteLastSpell();
        }

        //Cast Spells
        if (Input.GetKeyDown(KeyCode.Return))
        {
            curFactory.CastSpells();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameStart();
        }

        if (curPerson != null)
        {
            characterDescriptionText.text = curPerson.GetDescription();
        }

        spellQueueText.text = curFactory.GetSpells();

        if (gameRunning)
        {
            timeRemaining -= Time.deltaTime;
            timeLeftImage.fillAmount = timeRemaining / timeToWin;

            if (personsRemaining == 0) GameStop();
        }

    }

    void GameStart()
    {
        tutorialBox.SetActive(false);
        gameRunning = true;
        SpawnPerson();
    }

    void GameStop()
    {
        gameRunning = false;
        tutorialBox.SetActive(true);
        if (personsRemaining > 0)
        {
            Debug.Log("Lose");
            tutorialText.text = "You lose... Press SPACE to Retry.";
        } else
        {
            Debug.Log("Win");
            tutorialText.text = "You win! Press SPACE to play again!";
        }
    }

    public void CastSpell(string spell)
    {
        curFactory.NewSpell(spell);
    }

    //Spell Creation
    public void NewAttack(Spell spell)
    {
        if (!curPerson.CompareAffliction(spell)) Strike();
        if (curPerson.GetDescription() == "") Success();
    }

    #region Game Functionality
    //Spawn Person
    private void SpawnPerson()
    {
        curPerson = new Person((int) Random.Range(afflictionRange.x, afflictionRange.y));
    }

    //Wrong Spell
    private void Strike()
    {
        Debug.Log("Strike!");
        //strikeCount++;
        //if (strikeCount == 3) GameOver();
    }

    //Right Spell
    private void Success()
    {
        Debug.Log("Success!");
        personsRemaining--;
        personsRemainingText.text = personsRemaining.ToString();
        Invoke("SpawnPerson", 1);
    }

    //Game End
    private void GameOver()
    {
        if (strikeCount == 3)
            Debug.Log("Strike Out! Game Over!");
        else
            Debug.Log("Time Up! Game Over!");
    }
    #endregion
}
