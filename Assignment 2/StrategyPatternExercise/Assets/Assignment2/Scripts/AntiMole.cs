/*****************************
 * Connor Wolf
 * AntiMole.cs
 * Assignment 2
 * Antimole
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiMole : Mole
{
    private void Awake()
    {
        moleSpeed = 5;
        moleStandbyTime = 2;
        scoreBonus = -100;

        MoleBehaviour = new AntiBehaviour();
        GetComponent<MeshRenderer>().material.color = Color.red;
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
