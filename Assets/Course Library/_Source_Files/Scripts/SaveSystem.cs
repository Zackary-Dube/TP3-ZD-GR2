using UnityEngine;
/*
using Newtonsoft.json;
*/
using System.IO;
/*
//  Contient tout les parametres d'une partie (score, nombre de vie, difficulte)
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
        
        var path = path.Combine(Application.persistentDataPath, $"game.save");
        // Voir ou il met le fichier text
        Debug.Log(path);
        File.WriteAllText(path, json, serializedSave, System.Text.Encoding.UTF8);
    }

//  Retourne un bool true/false selon si une sauvegarde existe
    public bool CheckHasSave() {
        var path = path.Combine(Application.persistentDataPath, $"game.save");

        if (File.Exists(path)) {
            return true;
        } else {
            return false;
        }
    }

/*
//  Retourne le GameState d'une sauvegarde existante en lisant le fichier texte (deserialisation avec JSONConvert)
    public static GameState LoadStateFromSave() {
        if (CheckHasSave()) {
            var serializedSave = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<GameSave>(serializedSave);
        }
    }

}
*/