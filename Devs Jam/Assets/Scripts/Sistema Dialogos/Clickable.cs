using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    private SpriteRenderer bur;
    // Start is called before the first frame update
    void Start()
    {
        bur = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        bur.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        bur.enabled = true;

    }

    private void OnMouseExit()
    {
        bur.enabled = false;
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Se habladuriza");
    }
}
