using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    private Bocadillo hablame;
    // Start is called before the first frame update
    void Start()
    {
        hablame = transform.GetChild(0).gameObject.GetComponent<Bocadillo>();
        hablame.esconde();
    }
    
    private void OnMouseEnter()
    {
        hablame.muestra();

    }

    private void OnMouseExit()
    {
        hablame.esconde();
    }

    private void OnMouseUpAsButton()
    {
        hablame.esconde();
        // Saca el dialogo
    }
}
