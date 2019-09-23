using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spr;
    Animator anim;
    private bool direccion;

    private void Start()
    {
        direccion = false;
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && gameObject.transform.position.x >-21)
            {
                anim.SetBool("IdleDer", false);
                anim.SetBool("IdleIzq", false);
                direccion = false;
                spr.flipX = true;
                this.gameObject.transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
                anim.SetBool("Izq", true);
                anim.SetBool("Der", false);
            }

            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && gameObject.transform.position.x < 11)
            {
                anim.SetBool("IdleDer", false);
                anim.SetBool("IdleIzq", false);
                direccion = true;
                spr.flipX = false;
                this.gameObject.transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
                anim.SetBool("Izq", false);
                anim.SetBool("Der", true);
            }

        }
        else
        {
            anim.SetBool("Izq", false);
            anim.SetBool("Der", false);
            if (direccion)
            {
                anim.SetBool("IdleDer", true);
                anim.SetBool("IdleIzq", false);
            }
            else
            {
                anim.SetBool("IdleIzq", true);
                anim.SetBool("IdleDer", false);
            }
        }
        
    }
}
