using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.gameObject.transform.position += new Vector3(0,2,0) * Time.deltaTime; 
            }

            if (Input.GetKey(KeyCode.S))
            {
                this.gameObject.transform.position += new Vector3(0, -2, 0) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.gameObject.transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
            }

        }
        
    }
}
