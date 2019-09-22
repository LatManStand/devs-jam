using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoliManager : MonoBehaviour
{
    public GameObject conversacion;
    public GameObject titulo;

    // Start is called before the first frame update
    void Start()
    {
        titulo.SetActive(false);
        conversacion.SetActive(false);
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.3f);
        titulo.SetActive(true);
        yield return new WaitForSeconds(3.7f);
        titulo.SetActive(false);
        conversacion.SetActive(true);
    }
}
