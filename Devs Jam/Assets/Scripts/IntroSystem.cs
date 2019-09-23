using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSystem : MonoBehaviour
{
    public string siguienteEscena;
    public GameObject titulo;
    public GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.4f);
        texto.SetActive(true);
        yield return new WaitForSeconds(3.8f);
        titulo.SetActive(true);
        texto.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        titulo.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.LoadScene(siguienteEscena);
    }

    
}
