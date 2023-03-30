using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager manager;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    // Encryption
    [SerializeField] private bool useEncryption;

    private FileHandler dataHandler;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else
        {
            Debug.Log("Found more than one Data Persistance Manager in the scene");
        }

        this.dataHandler = new FileHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data was found! Initializing data to defaults.");
            NewGame();
        }

        // Push the loaded data to all other scripts which implememnts IDataPersistance interface
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        // Debug.Log("Loaded score = " + gameData.score);
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);

        // Debug.Log("Saved score = " + gameData.score);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
