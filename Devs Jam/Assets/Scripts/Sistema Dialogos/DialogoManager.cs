using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public struct DialogoBox
{
    public bool interrumpido;
    public bool pjIzquierda;
    public string texto;
}

public class DialogoManager : MonoBehaviour
{
    public Sprite nombrePJ1;
    public Sprite nombrePJ2;
    public GameObject GOPJ1;
    public GameObject GOPJ2;
    public GameObject buttonContinuar;
    public Text textoDialogo;
    public GameObject nombre1;
    public GameObject nombre2;
    DialogoEntrePersonajes info;

    private int posicionFrase;
    string pathTexto = "Texto/Casos/";
    public string nombreDialogo;


    // ------------------
    public float countdownValue;
    public GameObject canvas;
    private float currCountdownValue;
    private bool corutina;

    // Start is called before the first frame update
    void Start()
    {
        posicionFrase = -1;

        LoadJSON();

        EmpezarDialogo();

        corutina = true;
    }


    private void Update()
    {
        if (!corutina)
        {
            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
            {
                Continuar();
            }
        }
    }

    private void EmpezarDialogo()
    {
        //Corrutina para empezar unos segundos despues de haber iniciado la escena.
        StartCoroutine(StartCountdown());
        //Continuar();
    }

    public void Continuar()
    {
        if(posicionFrase >= info.Frases.Count)
        {
            //Fin dialogo;
            return;
        }

        posicionFrase++;
        //Cambiamos la imagen
        if (info.Frases[posicionFrase].pjIzquierda == 1)
        {
            GOPJ1.SetActive(true);
            GOPJ2.SetActive(false);

            nombre1.SetActive(true);
            nombre2.SetActive(false);

            GameObject name1 = nombre1.transform.GetChild(0).gameObject;
            name1.GetComponent<Text>().text = info.Frases[posicionFrase].nombrePJ;
        }
        else
        {
            GOPJ1.SetActive(false);
            GOPJ2.SetActive(true);

            nombre2.SetActive(true);
            nombre1.SetActive(false);

            GameObject name2 = nombre2.transform.GetChild(0).gameObject;
            name2.GetComponent<Text>().text = info.Frases[posicionFrase].nombrePJ;
        }

        //Mostramos el texto
        StopAllCoroutines();
        StartCoroutine(EscribirTexto(info.Frases[posicionFrase].texto));
    }

    IEnumerator EscribirTexto(string texto)
    {
        corutina = true;
        buttonContinuar.SetActive(false);
        textoDialogo.text = "";

        foreach (char letra in texto.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return null;
        }

        //¿Es interrumpido?
        if (info.Frases[posicionFrase].interrumpido == 1)
        {
            yield return new WaitForSeconds(0.5f);
            Continuar();
        }
        else
        {
            buttonContinuar.SetActive(true);
        }
        corutina = false;
    }

    private void LoadJSON()
    {

        var jsonModulos = Resources.Load<TextAsset>(pathTexto + nombreDialogo);
        info = JsonUtility.FromJson<DialogoEntrePersonajes>(jsonModulos.ToString());
    }

    public IEnumerator StartCountdown()
    {
        corutina = true;
        canvas.GetComponent<Canvas>().enabled = false;
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(0.5f);
            currCountdownValue--;
        }
        Continuar();
        canvas.GetComponent<Canvas>().enabled = true;
        corutina = false;
    }
}
