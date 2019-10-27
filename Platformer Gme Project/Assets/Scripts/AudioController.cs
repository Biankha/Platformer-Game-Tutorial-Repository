using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))//running
        {
            anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp(KeyCode.D)) //back to idle
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.A))//running
        {
            anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp(KeyCode.A)) //back to idle
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))//running
        {
            anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) //back to idle
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))//running
        {
            anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) //back to idle
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.W))//jump
        {
            anim.SetInteger("State", 3);
        }

        if (Input.GetKeyUp(KeyCode.W)) //back to idle
        {
            anim.SetInteger("State", 0);
        }
    }

    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKeyUp(KeyCode.W)) //back to idle
            {
            anim.SetInteger("State", 0);
            }
        }
    }
}

