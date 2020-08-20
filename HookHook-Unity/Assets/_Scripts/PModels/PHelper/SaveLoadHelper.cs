using System.IO;
using UnityEngine;

namespace PHelper
{
    public class SaveLoadHelper
    {
        public static void Save(string path, object data)
        {
            string destination = Application.persistentDataPath + path + ".json";
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(destination, json);
        }

        public static string Load(string path)
        {
            string destination = Application.persistentDataPath + path + ".json";
            if (File.Exists(destination))
                return File.ReadAllText(destination);
            return null;
        }
    }
}