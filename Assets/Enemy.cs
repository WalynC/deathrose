using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject burrow, physical, firing;

    public void BeginBurrow()
    {
        burrow.SetActive(true);
        physical.SetActive(false);
        firing.SetActive(false);
    }

    public void EndBurrow()
    {
        physical.SetActive(true);
        burrow.SetActive(false);
        EnemyManager.unburrowed.Add(this);
    }

    public void BeginFiring()
    {
        firing.SetActive(true);
    }

    public void EndFiring()
    {
        firing.SetActive(false);
    }

    public void FireAtSeed()
    {

    }
}
