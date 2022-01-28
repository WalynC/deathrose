using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;
    public IntEvent moneyChangedEvent;

    public int moneyCount = 1000;

    void Start()
    {
        instance = this;
        moneyChangedEvent?.Invoke(moneyCount);
    }

    public bool TryPurchase(int cost)
    {
        return cost <= moneyCount;
    }

    public void ChangeMoneyCount(int change)
    {
        moneyCount += change;
        moneyChangedEvent?.Invoke(moneyCount);
    }
}
