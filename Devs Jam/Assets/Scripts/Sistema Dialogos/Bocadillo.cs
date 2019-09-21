using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bocadillo : MonoBehaviour
{
    SpriteRenderer mio;
    MeshRenderer texto;

    // Start is called before the first frame update
    void Start()
    {
        mio = gameObject.GetComponent<SpriteRenderer>();
        mio.enabled = false;
        texto = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        texto.enabled = false;
    }

    public void muestra()
    {
        mio.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        mio.enabled = true;
        texto.enabled = true;
        StopCoroutine(tiempo());
    }

    public void esconde()
    {
        mio.enabled = false;
        texto.enabled = false;
    }

    public void actua()
    {
        mio.enabled = !mio.enabled;
        texto.enabled = !texto.enabled;
        StartCoroutine(tiempo());
    }

    IEnumerator tiempo()
    {
        yield return new WaitForSeconds(4f);
        mio.enabled = false;
        texto.enabled = false;
    }
}
