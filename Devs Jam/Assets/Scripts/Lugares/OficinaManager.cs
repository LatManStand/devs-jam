using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OficinaManager : MonoBehaviour
{
    public GameObject background;

    [Space(5)]
    public GameObject button1;
    public GameObject button2;

    [Space(5)]
    [InspectorName("Informe")]
    public GameObject caso1Info;
    public GameObject caso2Info;
    public GameObject caso3Info;

    [Space(5)]
    [InspectorName("Interrogar")]
    public GameObject caso1Int;
    public GameObject caso2Int;
    public GameObject caso3Int;

    [Space(5)]
    [InspectorName("Investigar")]
    public GameObject caso1Inv;
    public GameObject caso2Inv;
    public GameObject caso3Inv;

    [Space(5)]
    [InspectorName("Carpeta")]
    public GameObject Carpeta;
    public GameObject Hoja1;
    public GameObject Hoja2;
    public GameObject Icono;
    public GameObject Clip;
    public GameObject Hoja1Int;
    public GameObject Hoja2Int;
    public GameObject Hoja1Inv;
    public GameObject Hoja2Inv;

    // Start is called before the first frame update
    void Start()
    {
        button1.SetActive(true);
        button2.SetActive(false);
        caso1Info.SetActive(false);
        caso2Info.SetActive(false);
        caso3Info.SetActive(false);
        ActivarCarpeta();
        if (GameManager.instance.getNumCaso() == 1)
        {
            caso1Info.SetActive(true);
            caso1Int.SetActive(true);
            caso2Int.SetActive(false);
            caso3Int.SetActive(false);

            caso1Int.SetActive(true);
            caso2Int.SetActive(false);
            caso3Int.SetActive(false);
        }
        else if (GameManager.instance.getNumCaso() == 2)
        {
            caso2Info.SetActive(true);
            caso1Int.SetActive(false);
            caso2Int.SetActive(true);
            caso3Int.SetActive(false);

            caso1Int.SetActive(false);
            caso2Int.SetActive(true);
            caso3Int.SetActive(false);
        }
        else
        {
            caso3Info.SetActive(true);
            caso1Int.SetActive(false);
            caso2Int.SetActive(false);
            caso3Int.SetActive(true);

            caso1Int.SetActive(false);
            caso2Int.SetActive(false);
            caso3Int.SetActive(true);
        }

        if (GameManager.instance.getDia() == 1)
        {
            Hoja1Int.SetActive(true);
            Hoja2Int.SetActive(true);
            Hoja2Inv.SetActive(false);
            Hoja1Inv.SetActive(false);
        }
        else if(GameManager.instance.getDia() == 2)
        {
            Hoja1Int.SetActive(false);
            Hoja2Int.SetActive(false);
            Hoja2Inv.SetActive(true);
            Hoja1Inv.SetActive(true);
        }
        else
        {
            button1.SetActive(false);
            button2.SetActive(true);
        }
    }

    public void ActivarCarpeta()
    {
        Carpeta.SetActive(true);
        Hoja1.SetActive(true);
        Hoja2.SetActive(true);
        Icono.SetActive(true);
        Clip.SetActive(true);
    }

    public void CargarEscena(string nombre)
    {
        GameManager.instance.LoadScene(nombre);
    }

    public void pasar()
    {
        GameManager.instance.pasarDia();

    }
}
