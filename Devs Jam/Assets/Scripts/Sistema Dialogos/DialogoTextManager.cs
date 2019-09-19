using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class DialogoTextManager : MonoBehaviour
{
    public GameObject buttonContinuar;
    public Text textoDialogo;
    public GameObject nombre1;
    public List<string> frases;

    public string nombreBoxPJ1;
    public string nombreBoxPJ2;

    private int numCaso;

    string pathTexto = "Texto/Intro/Caso";
    private int posicionFrase;
    private string nombreCaso;

    // Start is called before the first frame update
    void Start()
    {
        posicionFrase = -1;
        nombre1.SetActive(true);

        numCaso = 0;

        LoadJSON();

        EmpezarDialogo();
    }

    private void EmpezarDialogo()
    {
        //Corrutina para empezar unos segundos despues de haber iniciado la escena.
        Continuar();
    }

    public void Continuar()
    {
        if(posicionFrase >= frases.Count)
        {
            //Fin dialogo;
            return;
        }

        posicionFrase++;

        //Mostramos el texto
        StopAllCoroutines();
        StartCoroutine(EscribirTexto(frases[posicionFrase]));
    }

    IEnumerator EscribirTexto(string texto)
    {
        buttonContinuar.SetActive(false);
        textoDialogo.text = "";

        foreach (char letra in texto.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return null;
        }

        buttonContinuar.SetActive(true);
    }

    private void LoadJSON()
    {

        var jsonModulos = Resources.Load<TextAsset>(pathTexto + numCaso);
        InfoIntroCaso info = JsonUtility.FromJson<InfoIntroCaso>(jsonModulos.ToString());

        nombreCaso = info.NombreCaso;
        frases = info.Frases;
    }
}
