//using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class GameSettingPanel : MonoBehaviour
{
    public float volumeMusique;
    public bool OnOffParticules;
    public float difficulty;

    //  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //  Update is called once per frame
    void Update()
    {
        
    }

    public static float SoundVolume {
        get => PlayerPrefs.GetFloat("SoundVolume", defaultValue: 1f);
        set {
            PlayerPrefs.SetFloat("SoundVolume", value);
            PlayerPrefs.Save(); // pour sauvegarder immédiatement
        }
    }
    public static bool ParticlesEnabled {
        get => PlayerPrefs.GetInt("ParticulesEnabled", 1) == 1;
        set {
            PlayerPrefs.SetInt("ParticulesEnabled", value ? 1 : 0); 
            PlayerPrefs.Save();
        }
    }
    public static float Difficulty
    {
        get => PlayerPrefs.GetFloat("Difficulty", defaultValue: 1f);
        set
        {
            PlayerPrefs.SetFloat("Difficulty", value);
            PlayerPrefs.Save(); // pour sauvegarder immédiatement
        }
    }
}
