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

    private AudioSource musicSource;

/*
    Start is called once before the first execution of Update after the MonoBehaviour is created
    Initialise la source audio
    Initialise les UI
    Configure le toggle des particules avec le listener
    Cache le panneau de parametre et affiche le menu
*/
    void Start() {
        musicSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        volumeSlider.value = GameSettingPanel.SoundVolume;
        musicSource.volume = volumeSlider.value;
        particuleToggle.onValueChanged.AddListener(OnToggleParticules);
        particuleToggle.isOn = GameSettingPanel.ParticlesEnabled;
        parameters.SetActive(false);

        difficulty.value = GameSettingPanel.Difficulty;
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
