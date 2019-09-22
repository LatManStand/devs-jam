using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDecisionAnimacion : MonoBehaviour
{
    public GameObject tick;

    private void Start()
    {
        tick.SetActive(false);
    }

    public void ActionButton()
    {
        //Lo que pasa
    }

    public void OnMouseEnter()
    {
        tick.SetActive(true);
    }

    public void OnMouseExit()
    {
        tick.SetActive(false);
    }
}
