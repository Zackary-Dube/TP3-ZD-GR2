using UnityEngine;

public class GameSettingPanel : MonoBehaviour
{
    public PlayerPrefs player;
    public float volumeMusique;
    public bool OnOffParticules;


    //  Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    //  Update is called once per frame
    void Update()
    {

    }

    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolume", defaultValue: 1f);
        set => PlayerPrefs.SetFloat("SoundVolume", value);
    }
}
