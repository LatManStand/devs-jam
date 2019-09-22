using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampusSystem : MonoBehaviour
{
    public GameObject entrada;
    public GameObject pasillo;
    public GameObject clase;
    public GameObject comedor;

    private void Start()
    {
        volverEntrada();
    }

    public void irComedor()
    {
        entrada.SetActive(false);
        pasillo.SetActive(false);
        clase.SetActive(false);
        comedor.SetActive(true);
    }

    public void irPasillo()
    {
        entrada.SetActive(false);
        pasillo.SetActive(true);
        clase.SetActive(false);
        comedor.SetActive(false);
    }

    public void entrarClase()
    {
        entrada.SetActive(false);
        pasillo.SetActive(false);
        clase.SetActive(true);
        comedor.SetActive(false);
    }

    public void volverEntrada()
    {
        entrada.SetActive(true);
        pasillo.SetActive(false);
        clase.SetActive(false);
        comedor.SetActive(false);
    }

    public void pasarDia()
    {
        GameManager.instance.pasarDia();
    }
}
