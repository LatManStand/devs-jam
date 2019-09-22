using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationMenuLoadScript : MonoBehaviour
{
    public int slot;
    public GameObject barra1;
    public GameObject barra2;
    public Text texto1;
    public Text texto2;

    private void Start()
    {
        texto2.text = "";

        int numCaso = GameManager.instance.existeSlotPartidaGuardada(slot);
        if (numCaso != 0)
        {
            switch (numCaso)
            {
                case 1:
                    texto1.text = "Caso 1: Greg y el robo";
                    break;
                case 2:
                    texto1.text = "Caso 2: Tonny y la violación";
                    break;
                case 3:
                    texto1.text = "Caso 3: Salvino";
                    break;
            }
            texto2.text = "Día " + GameManager.instance.getDiaPartidaGuardada(slot);
        }

        barra1.SetActive(false);
        barra2.SetActive(false);
    }

    private void OnEnable()
    {
        if (GameManager.instance)
        {
            if (GameManager.instance.getIsCargarPartida())
            {
                texto1.text = "No hay partida guardada";
            }
            else
            {
                texto1.text = "Nueva partida";
            }
        }
    }

    public void ActionButton()
    {
        if (GameManager.instance.getIsCargarPartida())
        {
            if (GameManager.instance.existeSlotPartidaGuardada(slot) != 0)
            {
                GameManager.instance.LoadData(slot);
                GameManager.instance.LoadScene("EscenaDia");
            }
        }
        else
        {
            GameManager.instance.StartGame(slot);
        }
    }

    public void OnMouseEnter()
    {
        barra1.SetActive(true);
        barra2.SetActive(true);
    }

    public void OnMouseExit()
    {
        barra1.SetActive(false);
        barra2.SetActive(false);
    }
}
