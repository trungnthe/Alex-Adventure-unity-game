
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumnSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        //musicSlider.value = 1;
        //SFXSlider.value = 1;

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
            LoadSFXVolume();
        }else
        {
            setMusicVolume();
            setSFXVolume();
        }
    }
    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);

    }

    public void setSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);

    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        setMusicVolume();
    }

    private void LoadSFXVolume()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        setSFXVolume();
    }
}
