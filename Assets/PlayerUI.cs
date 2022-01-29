using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    public TextMeshProUGUI money, moneyPreview, buildName;

    private void Start()
    {
        instance = this;
        buildName.text = "Building: Roots";
    }

    public void UpdateMoneyCounter(int count)
    {
        money.text = count.ToString();
    }

    public void UpdateBuildingName(string name)
    {
        buildName.text = "Building: "+ name;
    }

    public void UpdateCostPreview(bool active, int amount)
    {
        moneyPreview.gameObject.SetActive(active);
        moneyPreview.transform.position = Input.mousePosition;
        moneyPreview.text = amount.ToString();
    }
}
