using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour {

    private static bool fromSaveSystem = true;

/*  
    Start is called once before the first execution of Update after the MonoBehaviour is created
    Verifier qu'on se trouve dans une scene valide (menu ou game)
    (si c'est _source, il va "loader" la scene menu automatiquement)
*/  
    void Start() {
        if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Game") {
            GoToMenu();
        }
    }

//  Update is called once per frame
    void Update() {

    }

//  Charge la scene du menu principal
    public static void GoToMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

//  Demarre une nouvelle partie en desactivant le chargement depuis la sauvegarde
    public static void StartNewGame() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        fromSaveSystem = false;
        SceneManager.LoadScene("Game");
    }

//  Charge une partie sauvegardee
    public void LoadGame() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        fromSaveSystem = true;
        SceneManager.LoadScene("Game");
    }

/*
    Methode appelee automatiquement apres le chargement d'une scene
    On ne fait rien si ce n'est pas la scene du jeu
    On se desabonne de l'evenement pour eviter les doubles appels
    Verifie que le GameManager est bien present dans la scene Game
    Appelle le chargement des donnees dans le GameManager
*/
    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name != "Game") {
            return;
        }
        // On se desabonne pour eviter les appels multiples
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("[SceneNavigator] Scene Game chargee.");
        if (GameManager.instance == null) {
            Debug.LogWarning("[SceneNavigator] GameManager instance introuvable apres le chargement de la scene !");
            return;
        }
        Debug.Log("[SceneNavigator] GameManager trouve. Execution du chargement...");
        GameManager.instance.LoadGameFromGameManager(fromSaveSystem);
    }

//  Ferme l'application
    public static void ExitApp() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
