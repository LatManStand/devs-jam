using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    public void culpable()
    {
        if(GameManager.instance.getNumCaso() == 1)
        {
            GameManager.instance.setculpableGreg(true);
            GameManager.instance.pasarDia();
        }
        else if (GameManager.instance.getNumCaso() == 2)
        {
            GameManager.instance.setculpableTonny(true);
            GameManager.instance.pasarDia();
        }
        else
        {
            GameManager.instance.setFinal(true);
            GameManager.instance.LoadScene("Final1");
        }
    }

    public void inocente()
    {
        if (GameManager.instance.getNumCaso() == 1)
        {
            GameManager.instance.setculpableGreg(false);
            GameManager.instance.pasarDia();
        }
        else if (GameManager.instance.getNumCaso() == 2)
        {
            GameManager.instance.setculpableTonny(false);
            GameManager.instance.pasarDia();
        }
        else
        {
            GameManager.instance.setFinal(false);
            GameManager.instance.LoadScene("Final2");
        }
    }
}
