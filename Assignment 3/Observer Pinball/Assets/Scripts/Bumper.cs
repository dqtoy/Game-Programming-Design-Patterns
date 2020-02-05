using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Bumper leftBumper;
    public Bumper rightBumper;

    public bool lit = true;

    // Start is called before the first frame update
    void Start()
    {
        ToggleLit();
        ToggleLit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ToggleLit();
        //Push ball back
    }

    public void ToggleLit()
    {
        Invoke("TrueToggle", 0.1f);
    }

    private void TrueToggle()
    {
        lit = !lit;
        if (lit)
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
