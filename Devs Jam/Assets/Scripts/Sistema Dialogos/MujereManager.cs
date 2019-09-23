﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MujereManager : MonoBehaviour
{
    private GameObject converC1D1;
    private GameObject converC1D2;
    private GameObject converC2D1a;
    private GameObject converC2D1b;
    private GameObject converC2D2;
    private GameObject converC2D3;
    private GameObject converC3D1;

    // Start is called before the first frame update
    void Start()
    {
        converC1D1 = transform.GetChild(0).gameObject;
        converC1D2 = transform.GetChild(1).gameObject;
        converC2D1a = transform.GetChild(2).gameObject;
        converC2D1b = transform.GetChild(3).gameObject;
        converC2D2 = transform.GetChild(4).gameObject;

        converC1D1.SetActive(false);
        converC1D2.SetActive(false);
        converC2D1a.SetActive(false);
        converC2D1b.SetActive(false);
        converC2D2.SetActive(false);

        int caso = GameManager.instance.getNumCaso();
        int dia = GameManager.instance.getDia();

        if(caso == 1)
        {
            if (dia == 1)
            {
                converC1D1.SetActive(true);
            } else
            {
                converC1D2.SetActive(true);
            }
        } else if (caso == 2)
        {
            if (dia == 1)
            {
                if (GameManager.instance.getculpableGreg())
                {
                    converC2D1a.SetActive(true);
                } else
                {
                    converC2D1b.SetActive(true);
                }
            }
            else
            {
                converC2D2.SetActive(true);
            }
        } 



    }

    
}
