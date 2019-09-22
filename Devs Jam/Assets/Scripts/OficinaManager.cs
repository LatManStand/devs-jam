using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OficinaManager : MonoBehaviour
{
    public GameObject background;

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
        ActivarCarpeta();
        if (GameManager.instance.getDia() == 1)
        {
            Hoja1Int.SetActive(true);
            Hoja2Int.SetActive(true);
            Hoja2Inv.SetActive(false);
            Hoja1Inv.SetActive(false);
        }
        else
        {
            if(GameManager.instance.getDia() == 2)
            {
                Hoja1Int.SetActive(false);
                Hoja2Int.SetActive(false);
                Hoja2Inv.SetActive(true);
                Hoja1Inv.SetActive(true);
            }
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
}
