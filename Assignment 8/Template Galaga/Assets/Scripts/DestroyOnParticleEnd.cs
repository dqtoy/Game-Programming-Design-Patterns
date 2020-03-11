/*****************************************************************************
// File Name : DestroyOnParticleEnd.cs
// Author : Connor
// Creation Date : 3/9/2020
//
// Brief Description : Destroys a game object after its particle system ends
*****************************************************************************/
using UnityEngine;

public class DestroyOnParticleEnd : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }
}
