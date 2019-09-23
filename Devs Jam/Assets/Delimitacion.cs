using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delimitacion : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
       if(transform.position.x <= -44.0f)
        {
            Destroy(this);
        } 
    }
}
