using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{    
    public float countdownValue;
    float currCountdownValue;

    public GameObject objective;


    private void Start()
    {
        startCd();
    }

    public IEnumerator StartCountdown()
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        objective.SetActive(true);
    }

    public void startCd()
    {
        StartCoroutine(StartCountdown());
    }

    public void stopCD()
    {
        StopCoroutine(StartCountdown());
    }
}
