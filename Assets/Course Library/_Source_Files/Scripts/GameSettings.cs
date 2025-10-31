using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider volumeSlider;
    public GameObject parameters;
    public GameObject menu;
    

//  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        volumeSlider.value = GameSettingPanel.SoundVolume;
        musicSource.volume = volumeSlider.value;
        parameters.SetActive(false);
    }

//  Update is called once per frame
    void Update() {
        
    }
    /*
    public void updateVolume(float val) {
        GameSettingPanel.SoundVolume = val;
        musicSource.volume = val;
        AudioListener.volume = val;
    }
    */
    public void updateVolume()
    {

        musicSource.volume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
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
