using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{

    public GameObject gamePauseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamePauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPanel();
        }
    }

    public void OpenPanel()
    {
        gamePauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        gamePauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveGame()
    {
        GameManager.instance.SaveGame();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
