using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    private bool taken= false;

    // Update is called once per frame
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<HealthBar>().nowHealth -= damage;
            }
            Destroy(gameObject);
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                if (!taken)
                {
                    other.gameObject.GetComponent<HealthBar>().nowHealth -= damage;
                    taken = true;
                }
                Destroy(gameObject);
            }
            else if (other.gameObject.tag != "Enemy")
            {
                Destroy(gameObject);
            }
        }

    }

    
}
