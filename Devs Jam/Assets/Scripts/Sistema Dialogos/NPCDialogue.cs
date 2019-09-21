using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    private Bocadillo hablame;
    private Bocadillo texto;
    // Start is called before the first frame update
    void Start()
    {
        hablame = transform.GetChild(0).gameObject.GetComponent<Bocadillo>();
        hablame.esconde();
        texto = transform.GetChild(1).gameObject.GetComponent<Bocadillo>();
        texto.esconde();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<WorldTalker>().setLastNPC(this.gameObject);
            hablame.muestra();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<WorldTalker>().setLastNPC(null);
            hablame.esconde();
        }
    }



    public void talk()
    {
        hablame.esconde();
        texto.actua();
    }



}
