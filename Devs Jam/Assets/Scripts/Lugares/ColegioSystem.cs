using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColegioSystem : MonoBehaviour
{
    public GameObject entrada;
    public GameObject pasillo;
    public GameObject dire;

    private void Start()
    {
        volverEntrada();
    }

    public void irPasillo()
    {
        entrada.SetActive(false);
        pasillo.SetActive(true);
        dire.SetActive(false);
    }

    public void entrarDire()
    {
        entrada.SetActive(false);
        pasillo.SetActive(false);
        dire.SetActive(true);
    }

    public void volverEntrada()
    {
        entrada.SetActive(true);
        pasillo.SetActive(false);
        dire.SetActive(false);
    }

    public void pasarDia()
    {
        GameManager.instance.pasarDia();
    }
}
