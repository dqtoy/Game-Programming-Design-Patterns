using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Sword mySword;

    // Start is called before the first frame update
    void Start()
    {
        mySword = new BasicSword();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(mySword.GetDescription());
            Debug.Log(mySword.GetDamage());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mySword = new Sharpened(mySword);
        }
    }
}
