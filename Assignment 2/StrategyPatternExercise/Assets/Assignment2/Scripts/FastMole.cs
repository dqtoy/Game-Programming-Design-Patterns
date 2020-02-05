/*****************************
 * Connor Wolf
 * FastMole.cs
 * Assignment 2
 * Fast mole
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMole : Mole
{
    private void Awake()
    {
        moleSpeed = 10;
        moleStandbyTime = 1;
        scoreBonus = 50;

        MoleBehaviour = new FastBehaviour();
        GetComponent<MeshRenderer>().material.color = Color.yellow;
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
