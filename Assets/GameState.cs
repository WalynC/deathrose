using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public GameObject day, night, win, lose;
    public Transform seed, rose;
    int seedHealth = 10;

    public static bool daytime = true;

    private void Start()
    {
        instance = this;
        win.SetActive(false);
        lose.SetActive(false);
        DaytimeBegin();
    }

    public void DaytimeBegin()
    {
        foreach (Structure str in Structure.structures) str.Update();
        day.SetActive(true);
        night.SetActive(false);
        Vector3 plantPos = RootNetwork.instance.GetClosestRootPoint(rose.position);
        if (Vector3.Distance(plantPos, rose.position) > 5f) Lose();
        EnemyManager.instance.Deploy();
        foreach (Enemy e in EnemyManager.unburrowed)
        {
            seedHealth--;
            e.EndFiring();
        }
        if (seedHealth <= 0) Lose();
        CameraController.instance.transform.position = rose.position;
        seed.position = plantPos;
        daytime = true;
    }

    public void Lose()
    {
        day.SetActive(false);
        night.SetActive(false);
        lose.SetActive(true);
    }

    public void Win()
    {
        day.SetActive(false);
        night.SetActive(false);
        win.SetActive(true);

    }

    public void NighttimeBegin()
    {
        day.SetActive(false);
        night.SetActive(true);
        foreach (Enemy e in EnemyManager.burrowed)
        {
            e.EndBurrow();
        }
        foreach (Enemy e in EnemyManager.unburrowed)
        {
            e.BeginFiring();
        }
        EnemyManager.burrowed.Clear();
        RoseMovement.instance.controller.Move(seed.position-rose.position);
        CameraController.instance.transform.position = RoseMovement.instance.transform.position;
        daytime = false;
    }
}
