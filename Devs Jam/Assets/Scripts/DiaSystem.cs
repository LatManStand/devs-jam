using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaSystem : MonoBehaviour
{
    public string siguienteEscena;
    public GameObject titulo;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.aumentarDia();
        titulo.GetComponent<Text>().text = "Día " + GameManager.instance.getDia();
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(4f);
        titulo.SetActive(true);
        yield return new WaitForSeconds(4f);
        titulo.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        GameManager.instance.LoadScene(siguienteEscena);
    }
}
