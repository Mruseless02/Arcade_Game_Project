using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datapresistence : MonoBehaviour
{

    [SerializeField] private string fileName;
    [SerializeField] private bool StartGameIfNUll = true;
    [SerializeField] private bool encrptFile;
    public static Datapresistence instance { get; private set; }
    private List<IDataPresistence> dataPresistencesObject;
    private DataHandler handler;
    public GameData data;
    public static string loadedScene;
    public static int TotalEnemyKiled;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("MoreThen One Data Presistence");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.handler = new DataHandler(Application.persistentDataPath, fileName,encrptFile);
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Game Loaded");
        this.dataPresistencesObject = FindAllDataPresistenceObject();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("Game Save");
        SaveGame();
    }

    public void NewGame()
    {
        this.data = new GameData();
    }

    public void LoadGame()
    {
        this.data = handler.Load();
        if (data == null && StartGameIfNUll == true)
        {
            NewGame();
        }

        if (this.data == null)
        {
            Debug.Log("No Data");
            return;
        }

        foreach (IDataPresistence dataPresistenceObj in dataPresistencesObject)
        {
            dataPresistenceObj.LoadData(data);
        }
        MenuData();
    }

    public void SaveGame()
    {
        if (this.data == null)
        {
            Debug.LogWarning("NoData");
            return;
        }
        foreach (IDataPresistence dataPresistenceObj in dataPresistencesObject)
        {
            dataPresistenceObj.SaveData(ref data);
        }

        handler.Save(data);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPresistence> FindAllDataPresistenceObject()
    {
        IEnumerable<IDataPresistence> datapresistenceObject = FindObjectsOfType<MonoBehaviour>().OfType<IDataPresistence>();

        return new List<IDataPresistence>(datapresistenceObject);
    }

    public void MenuData()
    {
        loadedScene = this.data.Scene;
        TotalEnemyKiled = this.data.enemyKilledCount;
    }
    
    public bool HasGameData()
    {
        return data != null;
    }
}
