using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public int capacity = 500;
    int curCapacity;

    private void Start()
    {
        curCapacity = capacity;
    }

    public void Drain(int amount)
    {
        int reward = amount;
        curCapacity -= amount;
        bool drained = curCapacity < 0;
        if (drained) reward += curCapacity;
        PlayerMoney.instance.ChangeMoneyCount(reward);
        if (drained) Destroy(gameObject);
    }
}
