using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class JsonDataService
{
    public void SaveData<T>(string relativePath, T Data)
    {
        string path = GetPath(relativePath);
        string content = JsonConvert.SerializeObject(Data);

        WriteToFile(path, content);
    }

    public T LoadData<T>(string relativePath)
    {
        string path = GetPath(relativePath);
        string content = LoadFromFile(path);

        return JsonConvert.DeserializeObject<T>(content);
    }

    private void WriteToFile(string path, string content)
    {
        try
        {
            if (File.Exists(path))
            {
                Debug.Log("Data exists. Deleting old file and writing a new one!");
                File.Delete(path);
            }

            using FileStream stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path, content);
        }
        catch (Exception e)
        {
            Debug.LogError("Unable to save data due to: " + e.Message + e.StackTrace);
        }
    }

    private string LoadFromFile(string path)
    {
        if (File.Exists(path) == false)
        {
            Debug.LogError($"Cannot load file at {path}. File does not exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }

        try
        {
            return File.ReadAllText(path);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }

    private string GetPath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName);
    }
}
