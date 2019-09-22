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
        texto1.text = "Nueva partida";
        texto2.text = "";

        if (GameManager.instance.existeSlotPartidaGuardada(slot) != 0)
        {
            Debug.Log(GameManager.instance.existeSlotPartidaGuardada(slot));
            texto1.text = "Caso N: Nombre del caso";
            texto2.text = "Día " + GameManager.instance.getDiaPartidaGuardada(slot);
        }

        barra1.SetActive(false);
        barra2.SetActive(false);
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
            GameManager.instance.setSlot(slot);
            GameManager.instance.StartGame();
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
