using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversacionMundo : MonoBehaviour
{
    public float tiempo;
    private Bocadillo boc1;
    private Bocadillo boc2;
    private Bocadillo boc3;
    private Bocadillo boc4;
    private bool activado;

    // Start is called before the first frame update
    void Start()
    {
        boc1 = transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Bocadillo>();
        boc1.esconde();
        boc2 = transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Bocadillo>();
        boc2.esconde();
        boc3 = transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Bocadillo>();
        boc3.esconde();
        boc4 = transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<Bocadillo>();
        boc4.esconde();
        activado = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!activado)
            {
                StartCoroutine(dialogo());
            }
        }
    }

    public IEnumerator dialogo()
    {
        boc1.muestra();
        float currCountdownValue = tiempo;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(0.5f);
            currCountdownValue--;
        }

        boc1.esconde();
        boc2.muestra();
        currCountdownValue = tiempo;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(0.5f);
            currCountdownValue--;
        }

        boc2.esconde();
        boc3.muestra();
        currCountdownValue = tiempo;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(0.5f);
            currCountdownValue--;
        }

        boc3.esconde();
        boc4.muestra();
        currCountdownValue = tiempo;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(0.5f);
            currCountdownValue--;
        }
        boc4.esconde();
    }
}
