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
    [Space(5)]
    public string nombreBoxPJ1;
    public string nombreBoxPJ2;
    [Space(5)]
    private int numCaso;
    [Space(5)]
    public GameObject boxDialogo;
    public GameObject textoTitulo;

    string pathTexto = "Texto/Intro/Caso";
    private int posicionFrase;
    private string nombreCaso;

    private bool aparecerIntro;

    // Start is called before the first frame update
    void Start()
    {
        posicionFrase = -1;
        nombre1.SetActive(true);
        textoTitulo.SetActive(false);
        aparecerIntro = false;
        numCaso = 0;

        LoadJSON();

        EmpezarDialogo();
    }

    private void Update()
    {
        if (aparecerIntro)
        {
            boxDialogo.SetActive(false);
            textoTitulo.SetActive(true);

            StartCoroutine(loadNextScenne());
        }

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space))
        {
            Continuar();
        }

    }

    private void EmpezarDialogo()
    {
        //Corrutina para empezar unos segundos despues de haber iniciado la escena.
        Continuar();
    }

    public void Continuar()
    {
        posicionFrase++;
        if (posicionFrase >= frases.Count)
        {
            //Fin dialogo;
            aparecerIntro = true;
            return;
        }

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
        textoTitulo.GetComponent<Text>().text = info.NombreCaso;
        frases = info.Frases;
    }

    IEnumerator loadNextScenne()
    {
        yield return new WaitForSeconds(4.3f);
        aparecerIntro = false;
        textoTitulo.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        GameManager.instance.LoadScene("Interrogatorio");
    }
}
