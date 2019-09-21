using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public string escena;
    SpriteRenderer flechica;

    // Start is called before the first frame update
    void Start()
    {
        flechica = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        flechica.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<WorldTalker>().setLastDoor(this.gameObject);
            flechica.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<WorldTalker>().setLastDoor(null);
            flechica.enabled = false;
        }
    }

    public void abre()
    {
        SceneManager.LoadScene(escena);
    }


}
