using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private float bulletDirection = 0f;
    private float previousRotation = 0f;
    private int br = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            bulletDirection = Input.GetAxisRaw("Fire1");
            previousRotation = transform.rotation.eulerAngles.y;
            if (bulletDirection > 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (bulletDirection < 0)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            Shoot();
        }
    }
  

    void Shoot()
    {
        Instantiate(bullet,firePoint.position,firePoint.rotation);
    }
}
