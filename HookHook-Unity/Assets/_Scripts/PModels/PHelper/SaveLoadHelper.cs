using System.IO;
using UnityEngine;

namespace PHelper
{
    public class SaveLoadHelper
    {
        public static void Save(string path, object data)
        {
            string destination = Application.persistentDataPath + path + ".txt";
            FileStream file;
            if (File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);
            string json = JsonUtility.ToJson(data);
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine(json);
            }
            file.Close();
        }

        public static string Load(string path)
        {
            string data = null;
            string destination = Application.persistentDataPath + path + ".txt";
            FileStream file;
            if (!File.Exists(destination))
                Debug.LogError("File not found: " + destination);
            else
            if (new FileInfo(destination).Length > 0)
            {
                file = File.OpenRead(destination);
                data = File.ReadAllText(destination);
                file.Close();
            }
            return data;
        }
    }
}