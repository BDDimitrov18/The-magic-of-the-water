using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public int Starthealth = 100;
    [HideInInspector] public float nowHealth;

    private void Start()
    {
        nowHealth = Starthealth;
    }

    void Update()
    {
        healthBar.fillAmount =  nowHealth / Starthealth;
        if (nowHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
