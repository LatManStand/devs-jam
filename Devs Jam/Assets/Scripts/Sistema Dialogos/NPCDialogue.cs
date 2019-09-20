using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    private SpriteRenderer bur;
    private MeshRenderer mes;
    // Start is called before the first frame update
    void Start()
    {
        bur = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        bur.enabled = false;
        mes = transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
        mes.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<WorldTalker>().setLastNPC(this.gameObject);
            bur.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<WorldTalker>().setLastNPC(null);
            bur.enabled = false;
        }
    }



    public void talk()
    {
        bur.enabled = false;
        mes.enabled = !mes.enabled;
    }



}
