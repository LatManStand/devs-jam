using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MujereManager : MonoBehaviour
{
    private GameObject converC1D1;
    private GameObject converC1D2;
    private GameObject converC1D3;
    private GameObject converC2D1;
    private GameObject converC2D2;
    private GameObject converC2D3;
    private GameObject converC3D1;

    // Start is called before the first frame update
    void Start()
    {
        converC1D1 = transform.GetChild(0).gameObject;
        converC1D2 = transform.GetChild(0).gameObject;
        converC1D3 = transform.GetChild(0).gameObject;
        converC2D1 = transform.GetChild(0).gameObject;
        converC2D2 = transform.GetChild(0).gameObject;
        converC2D3 = transform.GetChild(0).gameObject;
        converC1D1 = transform.GetChild(0).gameObject;

        converC1D1.SetActive(false);
        converC1D2.SetActive(false);
        converC1D3.SetActive(false);
        converC1D1.SetActive(false);
        converC2D2.SetActive(false);
        converC2D3.SetActive(false);
        converC3D1.SetActive(false);

        int caso = GameManager.instance.getNumCaso();
        int dia = GameManager.instance.getDia();

        if(caso == 1)
        {
            if (dia == 1)
            {
                converC1D1.SetActive(true);
            } else if(dia == 2)
            {
                converC1D2.SetActive(true);
            } else
            {
                converC1D3.SetActive(true);
            }
        } else if (caso == 2)
        {
            if (dia == 1)
            {
                converC2D1.SetActive(true);
            }
            else if (dia == 2)
            {
                converC2D2.SetActive(true);
            }
            else
            {
                converC2D3.SetActive(true);
            }
        } else
        {
            converC3D1.SetActive(true);
        }



    }

    
}
