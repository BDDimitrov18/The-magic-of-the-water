using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    public float timer = 0f;
    private int shark = 0;
    [SerializeField]public GameObject[] sharks = new GameObject[3];

    

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 2f;
            Spawn();
        }
    }

    public void Spawn()
    {
        shark = Random.Range(0, 3);
        Instantiate(sharks[shark], transform.position, transform.rotation);
    }
}
