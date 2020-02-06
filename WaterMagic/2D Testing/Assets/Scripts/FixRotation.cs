using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector2(player.transform.position.x - 8f, Random.Range(player.transform.position.y-4f, player.transform.position.y + 4f));
    }
}
