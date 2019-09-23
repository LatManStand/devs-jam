using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguienteEscena : MonoBehaviour
{
    public void siguienteEscena()
    {
        GameManager.instance.LoadScene("IntroGame");
    }
}
