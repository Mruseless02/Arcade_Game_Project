using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datapresistence : MonoBehaviour
{

    [SerializeField] private string fileName;
    [SerializeField] private bool StartGameIfNUll = true;
    public static Datapresistence instance { get; private set; }
    private List<IDataPresistence> dataPresistencesObject;
    private DataHandler handler;
    private GameData data;
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
        this.handler = new DataHandler(Application.persistentDataPath, fileName);
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
        this.dataPresistencesObject = FindAllDataPresistenceObject();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
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

    public bool HasGameData()
    {
        return data != null;
    }
}
