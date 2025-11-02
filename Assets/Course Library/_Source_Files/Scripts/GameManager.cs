using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public float spawnRate = 1f;
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    private int nLives = 3;

    public static GameManager instance;

    public List<GameObject> lifeImages;

    public bool gameIsActive = true;

    public GameObject gameOverScreen;


    public AudioSource gameMusic;

    private SaveSystem saveSystem;

    // Start is called before the first frame update
    void Start()
    {
        gameMusic = GameObject.Find("Audio").GetComponent<AudioSource>();

        StartCoroutine(SpawnTargets());

        instance = this;
        Debug.Log("Game manager start");

        UpdateScore();
        UpdateLives();
        gameOverScreen.SetActive(false);

        saveSystem = gameObject.AddComponent<SaveSystem>();
        spawnRate = GameSettingPanel.Difficulty;
    }
    
    private void Awake()
    {
        Debug.Log("GameManager awake");
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameOver()
    {
        gameIsActive = false;

        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
/*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f - Time.timeScale;
        } 
        */
    }

    

    public void UpdateScore(int scoreToAdd = 0)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void UpdateLives(int livesToAdd = 0)
    {
        nLives += livesToAdd;

        for(int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].SetActive(i < nLives);
        }

        if (nLives <= 0) GameOver();
    }

    private IEnumerator SpawnTargets()
    {
        spawnRate = GameSettingPanel.Difficulty;


        while (gameIsActive)
        {
            yield return new WaitForSeconds(1f / spawnRate);
            var index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }


    public void SaveGame()
    {
        GameSave saveData = new GameSave()
        {
            difficulty = spawnRate,
            score = score,
            lives = nLives
        };
        saveSystem.SaveGame(saveData);
    }

    public void LoadGameFromGameManager()
    {
        Debug.Log("ici 1");
        var loaded = saveSystem.LoadStateFromSave();
        Debug.Log("ici 2");
        spawnRate = loaded.difficulty;
        score = loaded.score;
        nLives = loaded.lives;
        Debug.Log("difficulty : " + loaded.difficulty);
        Debug.Log("score : " + loaded.score);

        Debug.Log("lives : " + loaded.lives);
        UpdateScore();
        UpdateLives();

    }







}
