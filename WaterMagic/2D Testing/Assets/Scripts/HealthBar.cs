﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float Starthealth = 100;
    public float nowHealth;
    public Sprite[] sprites = new Sprite[4];
    public Animator anim;
  

    private void Start()
    {
        nowHealth = Starthealth;
    }

    void Update()
    {
        if (gameObject.tag == "Player")
        {
            if (nowHealth> 30f)
            {
                nowHealth = 30f;
            }
            if (nowHealth == 30f)
            {
                GameObject.Find("HealthHud").GetComponent<Image>().sprite = sprites[3];
            }
            else if (nowHealth >= 20f)
            {
                GameObject.Find("HealthHud").GetComponent<Image>().sprite = sprites[2];
            }
            else if (nowHealth >= 10f)
            {
                GameObject.Find("HealthHud").GetComponent<Image>().sprite = sprites[1];
            }
            else if(nowHealth == 0f)
            {
                GameObject.Find("HealthHud").GetComponent<Image>().sprite = sprites[0];
                anim.SetBool("Died", true);
            }
        }
        else
        {
            healthBar.fillAmount = nowHealth / Starthealth;
            if (nowHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
