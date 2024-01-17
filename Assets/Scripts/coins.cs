using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coins : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    void Start()
    {
        //PlayerPrefs.SetInt("coin", 0);
    }

    private void Update()
    {
        text.text = Convert.ToString(PlayerPrefs.GetInt("coin"));
        //Debug.Log(PlayerPrefs.GetInt("coin"));
    }
}
