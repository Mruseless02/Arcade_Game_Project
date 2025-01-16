using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataHandler
{
    private string dirPath = "";
    private string fileName = "";
    private readonly string encryptioncode = "hooman";

    public DataHandler(string dirPath, string fileName)
    {
        this.dirPath = dirPath;
        this.fileName = fileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dirPath, fileName);

        GameData dataLoaded = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                dataToLoad = EncryptionData(dataToLoad);
                dataLoaded = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error When Loading Data :" + fullPath + "\n" + e);
            }
        }

        return dataLoaded;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dirPath, fileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
           
            string dataToStore = JsonUtility.ToJson(data, true);

            dataToStore = EncryptionData(dataToStore);

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error While Trying to SaveData ro File" + fullPath + "\n" + e);
        }

    }

    private string EncryptionData(string data)
    {
        string modifiedData = "";
        for(int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptioncode[i % encryptioncode.Length]);
        }
        return modifiedData;
    }
}
