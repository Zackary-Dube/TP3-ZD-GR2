using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{

    //  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GoToMenu();
    }

//  Update is called once per frame
    void Update() {
        
    }

//  Ouvrir la scene du menu
    public static void GoToMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

//  Ouvir la scene du jeu
    public static void StartGame() {
        SceneManager.LoadScene("Game");
    }

//  Fermer l'application
    public static void ExitApp() {
        Application.Quit();
    }
    
}
