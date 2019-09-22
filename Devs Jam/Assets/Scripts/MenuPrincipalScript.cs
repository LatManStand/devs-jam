using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject menu1;
    public GameObject menu2;

    private void Start()
    {
        Menu1();
    }

    public void Menu1()
    {
        GameManager.instance.setIsCargarPartida(false);
        menu1.SetActive(true);
        menu2.SetActive(false);
    }

    public void EmpezarPartida()
    {
        GameManager.instance.setIsCargarPartida(false);
        menu1.SetActive(false);
        menu2.SetActive(true);
    }

    public void CargarPartida()
    {
        GameManager.instance.setIsCargarPartida(true);
        menu1.SetActive(false);
        menu2.SetActive(true);
    }
}
