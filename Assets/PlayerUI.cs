using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI money;

    public void UpdateMoneyCounter(int count)
    {
        money.text = count.ToString();
    }
}
