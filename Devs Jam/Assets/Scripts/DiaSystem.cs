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
        if (!GameManager.instance.getIsCargarPartida())
        {
            Debug.Log("Aumentamos el día");
            GameManager.instance.aumentarDia();
            GameManager.instance.SaveData();
        }
        titulo.GetComponent<Text>().text = "Día " + GameManager.instance.getDia();
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.3f);
        titulo.SetActive(true);
        yield return new WaitForSeconds(3.7f);
        titulo.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        GameManager.instance.LoadScene(siguienteEscena);
    }
}
