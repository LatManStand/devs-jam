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
    //Caso 1
    private bool tienePistaBedel;
    
    //Caso 2


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
        //Call the InitGame function to initialize the first level 
        InitGame();

        LoadData();
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

    //Called to start de game
    public void InitGame()
    {
    }

    //Called to start de game
    public void StartGame()
    {
        //Inicializamos los datos
        numCaso = 0;

        LoadScene("IntroGame");
    }

    //Called when the player die
    public void GameOver()
    {
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
}
