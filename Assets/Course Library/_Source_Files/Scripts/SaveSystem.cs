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

//  Retourne le chemin complet vers le fichier de sauvegarde
    private string GetSavePath() {
        return Path.Combine(Application.persistentDataPath, "game.save");
    }

//  Sauvegarde les donnees passees en argument dans un fichier JSON
    public void SaveGame(GameSave save) {
        string serializedSave = JsonConvert.SerializeObject(save, Formatting.Indented);
        string path = GetSavePath();
        Debug.Log($"Saving game to: {path}");
        File.WriteAllText(path, serializedSave, Encoding.UTF8);
    }

//  Verifie s'il existe deja une sauvegarde sur le disque
    public bool CheckHasSave() {
        return File.Exists(GetSavePath());
    }

//  Charge l'etat du jeu depuis le fichier de sauvegarde
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
