/*****************************
 * Connor Wolf
 * SlowMole.cs
 * Assignment 2
 * Slow Mole 
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMole : Mole
{
    private void Awake()
    {
        moleSpeed = 2;
        moleStandbyTime = 1;
        scoreBonus = 5;

        MoleBehaviour = new SlowBehaviour();
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    // Start is called before the first frame update
    void Start()
    {
        rising = 1;
        DoActivate();
    }

    private void Update()
    {
        base.DoUpdate();
    }

    private void OnMouseDown()
    {
        base.DoOnMouseDown();
    }
}
