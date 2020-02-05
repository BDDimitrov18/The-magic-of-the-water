﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;

    public Animator anim;

    [HideInInspector]public float timeleft = 0f;

    Rigidbody2D rbd;

    private void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);
        timeleft -= Time.deltaTime;
        if (timeleft <= 0f)
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    anim.SetBool("IsAttacking", true);
                }

            }
        }
    }
    void Shoot()
    {
        anim.SetBool("IsAttacking", false);
        if (timeleft <= 0f)
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            timeleft = 0.3f;
        }
    }
}