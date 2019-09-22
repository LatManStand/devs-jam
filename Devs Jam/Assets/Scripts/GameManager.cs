using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int numCaso;
    private int numDia;
    //Caso 1
    private bool tienePistaBedel;

    //Caso 2
    //Nada porque se lo comenta la hija

    //Caso 3
    private bool encerroSalvino;

    //Awake is always called before any Start functions
    void Awake()
    {
        Application.targetFrameRate = 300;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    //-------------------- FUNCTIONS --------------------

    public int getNumCaso()
    {
        return numCaso;
    }
    public int getDia()
    {
        return numDia;
    }

    public bool tienePistaCaso1()
    {
        return tienePistaBedel;
    }

    public bool getFinal()
    {
        return encerroSalvino;
    }

    public void aumentarDia()
    {
        numDia++;
        if(numDia >= 3)
        {
            numCaso++;
            numDia = 0;
        }
    }


    //Called to start de game
    public void StartGame()
    {
        //Inicializamos los datos
        numCaso = 0;
        numDia = 0;
        tienePistaBedel = false;
        encerroSalvino = false;

        LoadScene("IntroGame");
    }

    public void QuitGame()
    {
        SaveData();
        Application.Quit();
    }

    public void LoadScene(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    private IEnumerator LoadAsyncScene(string nameLevel)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameLevel);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void SaveData()
    {

        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        PlayerPrefs.GetString("");
    }

    public void ChangeData()
    {
        SaveData();
        LoadData();
    }

    public void loadDialogo()
    {
        LoadScene("Dialogo");
    }

    public void pasarDia()
    {
        //Pasar el dia
    }
}
