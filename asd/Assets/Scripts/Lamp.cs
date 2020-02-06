using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Lamp : MonoBehaviour
{
    public GameObject tofollow;
    public GameObject cam;
    public GameObject Player;
    public GameObject Stairs;

    private bool used = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!used)
            {
                var vcam = cam.GetComponent<CinemachineVirtualCamera>();
                vcam.Follow = tofollow.transform;
                PlayCam();
            }
        } 
    }

    void PlayCam()
    {
        tofollow.GetComponent<Animator>().SetTrigger("Follow");
    }

    void StopCam()
    {
        cam.GetComponent<CinemachineVirtualCamera>().Follow = Player.transform;
    }

    private void StairsStart()
    {
        Stairs.GetComponent<Animator>().SetTrigger("Start");
    }
}
