using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    private float volumeSounds;
    private float volumeMusic;
    [SerializeField] private Slider sound;
    [SerializeField] private Slider music;
    
    void Start()
    {
        volumeSounds = PlayerPrefs.GetFloat("VolumeSounds", 1);
        volumeMusic = PlayerPrefs.GetFloat("VolumeMusic", 1);
        sound.value = volumeSounds;
        music.value = volumeMusic;
    }

    public void ChangeSoundsVolume(Slider slider)
    {
        volumeSounds = slider.value;
        PlayerPrefs.SetFloat("VolumeSounds", volumeSounds);
    }

    public void ChangeMusicVolume(Slider slider)
    {
        volumeMusic = slider.value;
        PlayerPrefs.SetFloat("VolumeMusic", volumeMusic);
    }

}
