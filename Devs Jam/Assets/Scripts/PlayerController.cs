using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spr;

    private void Start()
    {
        spr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && gameObject.transform.position.x >-10.5) 
            {
                spr.flipX = true;
                this.gameObject.transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
            }

            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && gameObject.transform.position.x < 10.5)
            {
                spr.flipX = false;
                this.gameObject.transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
            }

        }
        
    }
}
