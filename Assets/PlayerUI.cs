using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    public TextMeshProUGUI money, moneyPreview;

    private void Start()
    {
        instance = this;
    }

    public void UpdateMoneyCounter(int count)
    {
        money.text = count.ToString();
    }

    public void UpdateCostPreview(bool active)
    {
        moneyPreview.gameObject.SetActive(active);
        moneyPreview.transform.position = Input.mousePosition;
        moneyPreview.text = PlantRoot.instance.previewPrice.ToString();
    }
}
