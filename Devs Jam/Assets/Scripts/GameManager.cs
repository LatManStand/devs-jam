using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int slot;
    private int numCaso;
    private int numDia;
    //Caso 1
    private bool tienePistaBedel;

    //Caso 2
    //Nada porque se lo comenta la hija

    //Caso 3
    private bool encerroSalvino;

    //Para el menu principal
    private bool isCargarPartida;

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
        isCargarPartida = false;
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
    public bool getIsCargarPartida()
    {
        return isCargarPartida;
    }
    public void setIsCargarPartida(bool value)
    {
        isCargarPartida = value;
    }

    public void setSlot(int _slot)
    {
        slot = _slot;
    }

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
    }

    public void cambiarCaso()
    {
        numCaso++;
        numDia = 0;
    }


    //Called to start de game
    public void StartGame(int _slot)
    {
        //Inicializamos los datos
        slot = _slot;
        numCaso = 1;
        numDia = 0;
        tienePistaBedel = false;
        encerroSalvino = false;

        SaveData();

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
        PlayerPrefs.SetInt("numCaso" + slot, numCaso);
        PlayerPrefs.SetInt("numDia" + slot, numDia);
        PlayerPrefs.Save();
    }

    public void LoadData(int _slot)
    {
        slot = _slot;
        numCaso = PlayerPrefs.GetInt("numCaso" + slot);
        numDia = PlayerPrefs.GetInt("numDia" + slot);
    }

    public int existeSlotPartidaGuardada(int _slot)
    {
        return PlayerPrefs.GetInt("numCaso" + _slot);
    }

    public int getDiaPartidaGuardada(int _slot)
    {
        return PlayerPrefs.GetInt("numDia" + slot);
    }

    public void loadDialogo()
    {
        LoadScene("Dialogo");
    }

    public void pasarDia()
    {
        LoadScene("CasaNoche");
    }
}
