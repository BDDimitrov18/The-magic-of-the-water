using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSBATLE : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("Fight");
            Destroy(gameObject);
        }
    }
}
