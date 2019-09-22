using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestauranteSystem : MonoBehaviour
{
    public GameObject entrada;
    public GameObject callejon;

    private void Start()
    {
        volverEntrada();
    }

    public void irCallejon()
    {
        entrada.SetActive(false);
        callejon.SetActive(true);
    }

    public void volverEntrada()
    {
        entrada.SetActive(true);
        callejon.SetActive(false);
    }
}
