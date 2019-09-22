using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public GameObject dialogo;
    private Bocadillo hablame;
    // Start is called before the first frame update
    void Start()
    {
        hablame = transform.GetChild(0).gameObject.GetComponent<Bocadillo>();
        hablame.esconde();
    }

    private void OnMouseEnter()
    {
        if (!dialogo.activeInHierarchy)
        {
            hablame.muestra();
        }
    }

    private void OnMouseExit()
    {
        hablame.esconde();
    }

    private void OnMouseUpAsButton()
    {
        if (!dialogo.activeInHierarchy)
        {
            hablame.esconde();

            dialogo.SetActive(true);
        }
    }
}
