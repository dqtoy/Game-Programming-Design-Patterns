/*****************************
 * Connor Wolf
 * GameManager.cs
 * Assignment 4
 * Drives the game
 *****************************/
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI swordDescriptionText;
    public TextMeshProUGUI targetNumberText;
    public TextMeshProUGUI timerText;

    private int targetNumber;

    private Sword mySword;
    public int starterEnchantmentCount;

    private bool gameRunning;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        mySword = new BasicSword();
        timer = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !gameRunning)
        {
            gameRunning = true;
            targetNumber = Random.Range(1, 20);
            targetNumberText.text = targetNumber.ToString();
            NewEnchants();
            //Debug.Log(mySword.GetDescription());
        }

        if (targetNumber == mySword.GetDamage() && gameRunning)
        {
            gameRunning = false;
            swordDescriptionText.text = "You Win! Press \"1\" to try again!";
        }

        if (gameRunning)
        {
            timer -= Time.deltaTime;
            timerText.text = "<color=green>" + Mathf.Round(timer).ToString();
            swordDescriptionText.text = mySword.GetDescription();

            if (timer <= 0)
            {
                swordDescriptionText.text = "Time up! Press \"1\" to try again...";
                gameRunning = false;
            }
        } else
        {
            timer = 60;
            timerText.text = "<color=green>" + timer.ToString();
        }
    }

    void NewEnchants()
    {
        mySword = new BasicSword();

        for(int i = 0; i != starterEnchantmentCount; i++)
        {
            int selectedEnchantment = Random.Range(0, 7);
            Enchant(selectedEnchantment);
        }
    }

    public void Enchant(int enchantment)
    {
        if (gameRunning)
        {
            switch (enchantment)
            {
                case 0:
                    mySword = new Polished(mySword);
                    break;

                case 1:
                    mySword = new Burned(mySword);
                    break;

                case 2:
                    mySword = new Sharpened(mySword);
                    break;

                case 3:
                    mySword = new Blessed(mySword);
                    break;

                case 4:
                    mySword = new Chipped(mySword);
                    break;

                case 5:
                    mySword = new Rusted(mySword);
                    break;

                case 6:
                    mySword = new Cursed(mySword);
                    break;
            }
        }
    }
}
