/*****************************
 * Connor Wolf
 * NormalMole.cs
 * Assignment 2
 * Normal Mole
 * ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMole : Mole
{
    private void Awake()
    {
        moleSpeed = 5;
        moleStandbyTime = 2;
        scoreBonus = 10;

        MoleBehaviour = new NormalBehaviour();
        GetComponent<MeshRenderer>().material.color = Color.green;
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
