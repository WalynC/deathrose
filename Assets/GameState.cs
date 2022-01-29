﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public GameObject day, night;
    public Transform seed, rose;

    private void Start()
    {
        instance = this;
        DaytimeBegin();
    }

    public void DaytimeBegin()
    {
        foreach (Structure str in Structure.structures) str.Update();
        day.SetActive(true);
        night.SetActive(false);
        Vector3 plantPos = RootNetwork.instance.GetClosestRootPoint(rose.position);
        if (Vector3.Distance(plantPos, rose.position) > 5f) Debug.Log("you lose");
        seed.position = plantPos;
    }

    public void NighttimeBegin()
    {
        day.SetActive(false);
        night.SetActive(true);
        rose.position = seed.position;
    }
}
