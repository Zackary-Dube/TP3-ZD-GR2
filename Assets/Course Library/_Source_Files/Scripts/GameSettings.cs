using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour {

    public GameObject parameters;
    public GameObject menu;
    public Slider volumeSlider;
    public Slider difficulty;
    public Toggle particuleToggle;

    public AudioSource musicSource;

/*
    Start is called once before the first execution of Update after the MonoBehaviour is created
    Initialise la source audio
    Initialise les UI
    Configure le toggle des particules avec le listener
    Cache le panneau de parametre et affiche le menu
*/
    void Start() {
/*
        GameObject[] audios = GameObject.FindGameObjectsWithTag("Audio");
        if (audios.Length > 1) {
            Destroy(audios[1]); // ou Destroy(gameObject) selon le contexte
        }
        if (musicSource == null) {
            musicSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        }
*/
        //musicSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        volumeSlider.value = GameSettingPanel.SoundVolume;
        musicSource.volume = volumeSlider.value;
        particuleToggle.onValueChanged.AddListener(OnToggleParticules);
        particuleToggle.isOn = GameSettingPanel.ParticlesEnabled;
        parameters.SetActive(false);

        difficulty.value = GameSettingPanel.Difficulty;
    }
    // Methode qui permet de toujours juste avoir un audio source meme si on revient au menu
    void Awake() {
        GameObject[] audios = GameObject.FindGameObjectsWithTag("Audio");

        if (audios.Length > 1) {
            for (int i = 1; i < audios.Length; i++) {
                Destroy(audios[i]);
            }
        }
        if (audios.Length > 0) {
            musicSource = audios[0].GetComponent<AudioSource>();
            DontDestroyOnLoad(audios[0]);
        } else {
            Debug.LogError("Aucun GameObject Audio avec tag 'Audio' trouvé !");
        }
    }

//  Update is called once per frame
    void Update() {
        
    }
    
//  Appelee lorsqu'on modifie la position du slider du volume
    public void updateVolume() {
        musicSource.volume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
        GameSettingPanel.SoundVolume = volumeSlider.value;
    }

//  Appelee lorsqu'on modifie le toggle des particules
    public void OnToggleParticules(bool isOn) {
        GameSettingPanel.ParticlesEnabled = isOn;
    }

//  Appelee lorsqu'on modifie la position du slider du niveau de difficulte
    public void UpdateDifficulty() {
        GameSettingPanel.Difficulty = difficulty.value;
    }

//  Affiche l'ecran des parametres et cache le menu principal
    public void OpenPanel() {
        parameters.SetActive(true);
        menu.SetActive(false);
    }

//  Ferme le panneau des parametre et reaffiche le menu principal
    public void ClosePanel() {
        parameters.SetActive(false);
        menu.SetActive(true);
    }
}
