using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.SetInt("coin", 0);
        Debug.Log(PlayerPrefs.GetInt("coin"));
        
    }

    public GameObject food;
    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                food.SetActive(false);
                PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin")+1);
            }
        }
}
