using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour {

    public GameObject gamePauseScreen;

/*
    Start is called once before the first execution of Update after the MonoBehaviour is created
    Assure que l'ecran de pause est cache au demarrage du jeu
*/
    void Start() {
        gamePauseScreen.SetActive(false);
    }

/*
    Update is called once per frame
    Si la touche Echap est pressee, on ouvre le menu de pause
*/
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OpenPanel();
        }
    }

//  Active l'interface de pause et arrete le temps
    public void OpenPanel() {
        if (!GameManager.instance.gameIsActive) {
            return;
        }
        gamePauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

//  Ferme l'interface de pause et remet le temps en marche
    public void ClosePanel() {
        gamePauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

//  Appelle la sauvegarde via le GameManager
    public void SaveGame() {
        GameManager.instance.SaveGame();
    }

//  Retourne au menu principal
    public void ReturnToMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

//  Quitte l'application
    public void QuitGame() {
        UnityEditor.EditorApplication.ExitPlaymode();
    }
}
