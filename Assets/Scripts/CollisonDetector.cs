using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetector : MonoBehaviour
{
    public int Health = 2;
    public GameObject h2;
    public GameObject h1;
    public GameObject panel;
    public GameObject parentPlayer;
    public GameObject childPlayer;
    public GameObject sifirNoktasi;
    public GameObject camera;
    public GameObject controllers;
    public GameObject coins;
    
    
        
    public GameObject reklamButonu;
    public GameObject normalButon;

    public AudioSource death;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Çarpışma tespit edildi!");
            Health--;
            childPlayer.transform.position = sifirNoktasi.transform.position;
            camera.transform.position = sifirNoktasi.transform.position;
        }
        else if (collision.gameObject.tag == "car")
        {
            Debug.Log("Çarpışma tespit edildi!");
            Health = Health-2;
        }
    }

    private void Start()
    {
        Health = 2;
        panel.SetActive(false);
        parentPlayer.SetActive(true);
        controllers.SetActive(true);
        coins.SetActive(true);
        
        Debug.Log(PlayerPrefs.GetInt("advert"));
    }

    private float yKonum;
    private void Update()
    {
        yKonum = transform.position.y;
        //Debug.Log(yKonum);
        
        if (Health == 2)
        {
            h1.SetActive(true);
            h2.SetActive(true);
        }
        else if (Health == 1)
        {
            h2.SetActive(false);
        }
        else if (Health <= 0)
        {
            h1.SetActive(false);
            Debug.Log("GameOver");
            death.Play();
            panel.SetActive(true);
            parentPlayer.SetActive(false);
            controllers.SetActive(false);
            coins.SetActive(false);
            PlayerPrefs.SetInt("advert", PlayerPrefs.GetInt("advert")+1);
            
            if (PlayerPrefs.GetInt("advert")%3==0)
            {
                normalButon.SetActive(false);
                reklamButonu.SetActive(true);
            }
            else
            {
                reklamButonu.SetActive(false);
                normalButon.SetActive(true);
            }
        }
        
        else if (yKonum < 3f)
        {
            h1.SetActive(false);
            h2.SetActive(false);
            Debug.Log("GameOver");
            panel.SetActive(true);
            parentPlayer.SetActive(false);
        }
        
    }
}
