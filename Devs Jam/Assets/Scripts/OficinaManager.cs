using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OficinaManager : MonoBehaviour
{
    public GameObject conversacionJefe;
    public GameObject titulo;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.getDia() == 1)
        {
            StartCoroutine(Animation());
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.3f);
        titulo.SetActive(true);
        yield return new WaitForSeconds(3.7f);
        titulo.SetActive(false);
    }
}
