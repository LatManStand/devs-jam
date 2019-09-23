using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheRandomGenerator : MonoBehaviour
{
    public float timeMax;
    public float probabilidad;
    public GameObject coche; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, 1000) <= probabilidad)
        {
            Instantiate(coche.transform, this.transform);
        }
    }
}
