using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        curFactory = new HealFactory();
        spellDamage = -1;
        spellQueueBox.color = new Color(1, 1, 0);
        spellQueueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
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
            SpawnPerson();
        }

        if (curPerson != null)
        {
            characterDescriptionText.text = curPerson.GetDescription();
        }


        spellQueueText.text = curFactory.GetSpells();
        
    }

    //Spell Creation
    public void NewAttack(Spell spell)
    {
        if (curPerson.CompareAffliction(spell)) Success();
        else Strike();
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
        strikeCount++;
        if (strikeCount == 3) GameOver();
    }

    //Right Spell
    private void Success()
    {
        Debug.Log("Success!");
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
