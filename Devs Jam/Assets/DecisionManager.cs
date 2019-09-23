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
            GameManager.instance.LoadScene("CasaNoche");
        }
        else if (GameManager.instance.getNumCaso() == 2)
        {
            GameManager.instance.setculpableTonny(true);
            GameManager.instance.LoadScene("CasaNoche");
        }
        else
        {
            GameManager.instance.setFinal(true);
            GameManager.instance.LoadScene("FinalMalo");
        }
    }

    public void inocente()
    {
        if (GameManager.instance.getNumCaso() == 1)
        {
            GameManager.instance.setculpableGreg(false);
            GameManager.instance.LoadScene("CasaNoche");
        }
        else if (GameManager.instance.getNumCaso() == 2)
        {
            GameManager.instance.setculpableTonny(false);
            GameManager.instance.LoadScene("CasaNoche");
        }
        else
        {
            GameManager.instance.setFinal(false);
            GameManager.instance.LoadScene("FinalBueno");
        }
    }
}
