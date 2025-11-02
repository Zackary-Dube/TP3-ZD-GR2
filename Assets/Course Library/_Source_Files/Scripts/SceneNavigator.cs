using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneNavigator : MonoBehaviour
{

    //  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Game")
        {
            GoToMenu();
        }



    }

    //  Update is called once per frame
    void Update() {

    }

    //  Ouvrir la scene du menu
    public static void GoToMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    //  Ouvir la scene du jeu
    public static void StartNewGame() {
        SceneManager.LoadScene("Game");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");

        Debug.Log("avant");
        if (GameManager.instance == null)
        {
            Debug.Log("GameManager instance est null");
        } else
        {
            GameManager.instance.LoadGameFromGameManager();

        }
        Debug.Log("apres");

    }

    //  Fermer l'application
    public static void ExitApp() {
        Application.Quit();
    }
    
}
