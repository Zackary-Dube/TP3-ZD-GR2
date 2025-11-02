using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Toggle particuleToggle;

    private AudioSource musicSource;
    public Slider volumeSlider;

    public Slider difficulty;

    public GameObject parameters;
    public GameObject menu;
    

//  Start is called once before the first execution of Update after the MonoBehaviour is created
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
    
    public void updateVolume() {
        musicSource.volume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
        GameSettingPanel.SoundVolume = volumeSlider.value;
    }


    public void OnToggleParticules(bool isOn)
    {
        GameSettingPanel.ParticlesEnabled = isOn;
    }
    
    public void UpdateDifficulty()
    {
        GameSettingPanel.Difficulty = difficulty.value;

    }


    //  Code a venir pour afficher mon menu
    public void OpenPanel() {
        parameters.SetActive(true);
        menu.SetActive(false);
    }

    public void ClosePanel()
    {
        parameters.SetActive(false);
        menu.SetActive(true);
    }
}
