using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public List<GameObject> targets;
    public List<GameObject> lifeImages;
    public GameObject gameOverScreen;
    public AudioSource gameMusic;
    public TextMeshProUGUI scoreText;
    public float spawnRate = 1f;
    public int score = 0;
    public bool gameIsActive = true;

    private SaveSystem saveSystem;
    private int nLives = 3;

/*
    Start is called before the first frame update
    Recupere la source audio
    Demarre l'apparition des cibles
    Affiche le score
    Affiche les vie
    Cache l'ecran de Game Over
    Definit la difficulte depuis les parametres
*/
    void Start() {
        if (!gameMusic && GameObject.Find("Audio")) {
            gameMusic = GameObject.Find("Audio").GetComponent<AudioSource>();
        }
        StartCoroutine(SpawnTargets());
        UpdateScore();
        UpdateLives();
        gameOverScreen.SetActive(false);
        spawnRate = GameSettingPanel.Difficulty;
    }

//  Update is called once per frame
    void Update() {

    }

/*
    Methode appelee avant Start
    Definit l'instance globale du GameManager
    Ajoute un composant SaveSystem
*/
    private void Awake() {
        instance = this;
        if (saveSystem == null)
        {
            saveSystem = gameObject.AddComponent<SaveSystem>();
        }
    }

//  Redemarre la scene actuelle 
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Time.timeScale = 1f;
    }

//  Termine la partie et affiche l'ecran de Game Over
    public void GameOver() {
        Time.timeScale = 0f;
        gameIsActive = false;
        gameOverScreen.SetActive(true);
    }

//  Met a jour le score et rafraichit l'affichage
    public void UpdateScore(int scoreToAdd = 0) {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

//  Met a jour le nombre de vies et l'affichage correspondant
    public void UpdateLives(int livesToAdd = 0) {
        nLives += livesToAdd;
        for(int i = 0; i < lifeImages.Count; i++) {
            lifeImages[i].SetActive(i < nLives);
        }
        if (nLives <= 0) {
            GameOver();
        }
    }

//  Coroutine pour faire apparaitre des cibles a un rythme regulier
    private IEnumerator SpawnTargets() {
        spawnRate = GameSettingPanel.Difficulty;
        while (gameIsActive) {
            yield return new WaitForSeconds(1f / spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

//  Sauvegarde l'etat actuel du jeu (score, vies, difficulte)
    public void SaveGame() {
        if (saveSystem == null) {
            Debug.LogError("SaveSystem non initialise !");
            return;
        }
        GameSave saveData = new GameSave() {difficulty = spawnRate, score = score, lives = nLives};
        saveSystem.SaveGame(saveData);
    }

//  Charge les donnees du jeu, soit depuis une sauvegarde, soit valeurs par defaut
    public void LoadGameFromGameManager(bool fromSaveSystem = true) {
        if(!fromSaveSystem) {
            spawnRate = 1;
            score = 0;
            nLives = 3;
        } else {
            if (saveSystem == null) {
                return;
            }
            var loaded = saveSystem.LoadStateFromSave();
            if (loaded == null) {
                return;
            }
            spawnRate = loaded.difficulty;
            score = loaded.score;
            nLives = loaded.lives;
        }
        Debug.Log($"Game charge : difficulty={spawnRate}, score={score}, lives={nLives}");
    }
}