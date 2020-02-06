using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkPrefab : MonoBehaviour
{
    public float speed =5f;
    public Rigidbody2D rb;
    public int damage = 15;
    bool allowed = true;
    public string direction = "horizontal";

    void Start()
    {
        if (direction == "horizontal")
        {
            rb.velocity = transform.right * speed;
        }
        else if (direction == "vertical")
        {
            rb.velocity = transform.up * speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && allowed)
        {
            other.gameObject.GetComponent<HealthBar>().nowHealth -= damage;
            allowed = false;
        }
    }
}
