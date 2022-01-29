using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseCanvas : MonoBehaviour
{
    public static LoseCanvas instance;
    public TextMeshProUGUI text;

    void Start()
    {
        instance = this;
    }
    
    public void ChangeText(string str)
    {
        text.text = str;
    }
}
