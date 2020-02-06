using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        //has 2 uses
        //fix the boss health bar
        //
        if (gameObject.layer == 5)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 4f);
        }
        else
        {
            transform.position = new Vector2(player.transform.position.x - 20f, Random.Range(player.transform.position.y - 4f, player.transform.position.y + 4f));
        }
  
    }    
}
