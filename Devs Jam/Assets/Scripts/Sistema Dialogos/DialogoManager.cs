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
    public string siguienteEscena;
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
    public string pathTexto = "Texto/Casos/Caso";
    public string nombreDialogo;
    public string nombreDialogo1;
    public string nombreDialogo2;
    public bool finalMalo;


    // ------------------
    public float countdownValue;
    public GameObject canvas;
    private float currCountdownValue;
    private bool corutina;

    // Start is called before the first frame update
    void Start()
    {
        finalMalo = false;
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
        posicionFrase++;
        if (posicionFrase >= info.Frases.Count)
        {
            //Fin dialogo
            canvas.GetComponent<Canvas>().enabled = false;
            NextEscena();
            return;
        }

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

        if (finalMalo)
        {
            //Añadir los sonidos del final malo
        }


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
        int numCaso = GameManager.instance.getNumCaso();
        int numDia = GameManager.instance.getDia();

        if(GameManager.instance.getNumCaso() == 2)
        {
            if (GameManager.instance.getculpableGreg())
            {
                Debug.Log(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo1);
                var jsonModulos = Resources.Load<TextAsset>(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo2);
                info = JsonUtility.FromJson<DialogoEntrePersonajes>(jsonModulos.ToString());
            }
            else
            {
                Debug.Log(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo2);
                var jsonModulos = Resources.Load<TextAsset>(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo2);
                info = JsonUtility.FromJson<DialogoEntrePersonajes>(jsonModulos.ToString());
            }
        }
        else if (GameManager.instance.getNumCaso() == 3)
        {
            if (GameManager.instance.getculpableGreg())
            {
                Debug.Log(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo1);
                var jsonModulos = Resources.Load<TextAsset>(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo2);
                info = JsonUtility.FromJson<DialogoEntrePersonajes>(jsonModulos.ToString());
            }
            else
            {
                Debug.Log(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo2);
                var jsonModulos = Resources.Load<TextAsset>(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo2);
                info = JsonUtility.FromJson<DialogoEntrePersonajes>(jsonModulos.ToString());
            }
        }
        else
        {
            Debug.Log(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo);
            var jsonModulos = Resources.Load<TextAsset>(pathTexto + numCaso + "/C" + numCaso + "D" + numDia + nombreDialogo);
            info = JsonUtility.FromJson<DialogoEntrePersonajes>(jsonModulos.ToString());
        }
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

    void NextEscena()
    {
        if (siguienteEscena != "")
        {
            GameManager.instance.LoadScene(siguienteEscena);
        }
    }

    public void cambiarDialogo(string dialogo)
    {
        nombreDialogo = dialogo;
    }
}
