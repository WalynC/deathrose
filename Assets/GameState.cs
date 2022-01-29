using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public GameObject day, night;
    public Transform seed, rose;

    public static bool daytime = true;

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
        EnemyManager.instance.Deploy();
        foreach (Enemy e in EnemyManager.unburrowed)
        {
            e.FireAtSeed();
            e.EndFiring();
        }
        CameraController.instance.transform.position = rose.position;
        seed.position = plantPos;
        daytime = true;
    }

    public void NighttimeBegin()
    {
        day.SetActive(false);
        night.SetActive(true);
        foreach (Enemy e in EnemyManager.burrowed)
        {
            e.EndBurrow();
            e.BeginFiring();
        }
        EnemyManager.burrowed.Clear();
        RoseMovement.instance.controller.Move(seed.position-rose.position);
        CameraController.instance.transform.position = RoseMovement.instance.transform.position;
        daytime = false;
    }
}
