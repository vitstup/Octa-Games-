using System.IO;
using UnityEngine;

public class SaveLoadUtility
{
    private string Path(string name) =>
        System.IO.Path.Combine(Application.persistentDataPath, $"{name}.json");

    // Можно также сделать Save и Load Ассинхронными, подключить к примеру UniTask. 

    public void Save<T>(T data, string name) where T : class // Можно убрать T : class дабы сериализовывать и структуры
    {
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Path(name), json);
    }

    public bool Load<T>(string name, out T result) where T : class // Можно убрать T : class дабы сериализовывать и структуры
    {
        try
        {
            var json = File.ReadAllText(Path(name));
            result = JsonUtility.FromJson<T>(json);
            return true;
        }
        catch
        {
            result = null; 
            // Можем вывести ошибку, также можем её и возвращать при необходимости 
            return true;
        }
    }

    public bool Exists(string name) => File.Exists(Path(name));
    public void Delete(string name) => File.Delete(Path(name));
}