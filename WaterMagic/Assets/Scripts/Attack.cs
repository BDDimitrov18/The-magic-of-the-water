using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject rat;
    public float damage = 10f;
    private GameObject player;
    bool attack = false;
    private float countdown = 0f;

    public void Update()
    {
        countdown -= Time.deltaTime;
        if (attack == true)
        {
            if (countdown <= 0f)
            {
                TakeDamage(player);
                countdown = 1f;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            attack = true;
            player = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            attack = false;
            countdown = 0f;
        }
    }

    private void TakeDamage(GameObject obj)
    {
        obj.GetComponent<HealthBar>().nowHealth -= damage;
    }

    void SpawnRat()
    {
        Instantiate(rat, spawnpoint.position, spawnpoint.rotation);
    }
}


