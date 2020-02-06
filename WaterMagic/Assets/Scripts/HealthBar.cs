using System.Collections;
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
    public Animator deathpanel;
    public Animator[] deathanim = new Animator[3];
    public GameObject health;
  

    private void Start()
    {
        nowHealth = Starthealth;
    }

    void Update()
    {
        if(gameObject.tag == "Boss")
        {
            if (nowHealth <= 0)
            {
                Destroy(health);
            }
        }
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
            else if(nowHealth <= 0f)
            {
                GameObject.Find("HealthHud").GetComponent<Image>().sprite = sprites[0];
                deathpanel.gameObject.SetActive(true);
                anim.SetBool("Died", true);
                gameObject.GetComponent<Movement>().moveallow = false;
                deathpanel.SetTrigger("Death");
                foreach (Animator an in deathanim)
                {
                    an.SetTrigger("StartTr");
                }
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
