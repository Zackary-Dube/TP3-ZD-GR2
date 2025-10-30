using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Slider volumeSlider;

//  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        volumeSlider.value = GameSettingPanel.SoundVolume;
    }

//  Update is called once per frame
    void Update() {
        
    }

    
        
        
        
}
