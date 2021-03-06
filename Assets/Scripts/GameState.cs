using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public GameObject day, night, both, win, lose;
    public Transform seed, rose;
    int seedHealth = 10;
    public TextMeshProUGUI healthText;

    bool gameOver = false;

    public static bool daytime = true;

    private void Start()
    {
        instance = this;
        win.SetActive(false);
        lose.SetActive(false);
        DaytimeBegin();
        healthText.text = "Health: " + seedHealth;
    }

    public void DaytimeBegin()
    {
        foreach (Structure str in Structure.structures) str.Update();
        day.SetActive(true);
        night.SetActive(false);
        Vector3 plantPos = RootNetwork.instance.GetClosestRootPoint(rose.position);
        if (Vector3.Distance(plantPos, rose.position) > 5f) Lose("The rose was too far away from its roots when the sun rose, and withered away");
        EnemyManager.instance.Deploy();
        foreach (Enemy e in EnemyManager.unburrowed)
        {
            seedHealth--;
            e.EndFiring();
        }
        healthText.text = "Health: " + seedHealth;
        if (seedHealth <= 0) Lose("The robots have destroyed the rose's seed");
        CameraController.instance.transform.position = rose.position;
        seed.position = plantPos;
        daytime = true;
    }

    public void Lose(string str)
    {
        if (gameOver) return;
        gameOver = true;
        LoseCanvas.instance.ChangeText(str);
        day.SetActive(false);
        night.SetActive(false);
        both.SetActive(false);
        lose.SetActive(true);
    }

    public void Win()
    {
        if (gameOver) return;
        gameOver = true;
        day.SetActive(false);
        night.SetActive(false);
        both.SetActive(false);
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
