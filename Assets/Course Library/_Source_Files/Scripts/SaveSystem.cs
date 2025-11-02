/*
using Newtonsoft.Json;
using System.IO;
using System.Text;
using UnityEngine;

//  Contient tout les parametres d'une partie (score, nombre de vie, difficulte)
[System.Serializable]
public class GameSave {
    public int stageProgress;
    public float score;
    public string lives;
}

public class SaveSystem : MonoBehaviour {
    
    //  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

//  Update is called once per frame
    void Update() {
        
    }

//  Sauvegarder un GameState dans un fichier texte sur le disque (Serialisation avec JSONConvert)
    public void SaveGame(GameSave save) {
        var serializedSave = JsonConvert.SerializeObject(save);
        
        var path = Path.Combine(Application.persistentDataPath, $"game.save");
        // Voir ou il met le fichier text
        Debug.Log(path);
        File.WriteAllText(path, serializedSave, System.Text.Encoding.UTF8);
    }

//  Retourne un bool true/false selon si une sauvegarde existe
    public bool CheckHasSave() {
        var path = Path.Combine(Application.persistentDataPath, $"game.save");

        if (File.Exists(path)) {
            return true;
        } else {
            return false;
        }
    }


//  Retourne le GameState d'une sauvegarde existante en lisant le fichier texte (deserialisation avec JSONConvert)
    public static GameSave LoadStateFromSave() {
        if (CheckHasSave()) {
            var serializedSave = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<GameSave>(serializedSave);
        }
    }

    public GameSave LoadStateFromSave()
    {
        string path = GetSavePath();

        if (!File.Exists(path))
        {
            Debug.LogWarning("No save file found!");
            return null;
        }

        string serializedSave = File.ReadAllText(path, Encoding.UTF8);
        return JsonConvert.DeserializeObject<GameSave>(serializedSave);
    }

}

*/




using Newtonsoft.Json;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public class GameSave {
    public float difficulty;
    public int score;
    public int lives;
}

public class SaveSystem : MonoBehaviour {

    private string GetSavePath() {
        return Path.Combine(Application.persistentDataPath, "game.save");
    }

    public void SaveGame(GameSave save) {
        string serializedSave = JsonConvert.SerializeObject(save, Formatting.Indented);
        string path = GetSavePath();

        Debug.Log($"Saving game to: {path}");
        File.WriteAllText(path, serializedSave, Encoding.UTF8);
    }

    public bool CheckHasSave() {
        return File.Exists(GetSavePath());
    }

    public GameSave LoadStateFromSave() {
        string path = GetSavePath();

        if (!File.Exists(path)) {
            Debug.LogWarning("No save file found!");
            return null;
        }

        string serializedSave = File.ReadAllText(path, Encoding.UTF8);
        return JsonConvert.DeserializeObject<GameSave>(serializedSave);
    }
}
