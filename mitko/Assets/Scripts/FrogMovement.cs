using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FrogMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D m_Rigidbody2D;
    public Vector3 m_Velocity=Vector3.zero;
    float xdif = 0f;
    public Animator anim;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    public GameObject frogSprite;

    
    private void FixedUpdate()
    {
        xdif = gameObject.transform.position.x - player.transform.position.x;
        if (xdif>1 && xdif<20)
        {
            frogSprite.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            Vector3 targetVelocityj = new Vector2(1 * -2,m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocityj, ref m_Velocity, m_MovementSmoothing);
            anim.SetBool("IsWalking", true);
        }
        else if(xdif < -1 && xdif > -20)
        {
            frogSprite.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Vector3 targetVelocityj = new Vector2(1 * 2, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocityj, ref m_Velocity, m_MovementSmoothing);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            m_Rigidbody2D.velocity = Vector3.zero;
            anim.SetBool("IsWalking", false);
        }
        
    }

}
