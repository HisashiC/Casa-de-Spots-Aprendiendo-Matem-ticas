using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioSource music;
    public Slider volume;
    public Slider sfxVolume;
    private float backgroundVolumen, backgroundSonidos;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        backgroundSonidos = 0.75f;
        backgroundVolumen = 0.75f;
        volume.value = PlayerPrefs.GetFloat("MusicVolume", backgroundVolumen);
        sfxVolume.value = PlayerPrefs.GetFloat("FxVolume", backgroundSonidos);
    }

    

    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
        PlayerPrefs.SetFloat("FxVolume", sfxVolume.value);
    }

    private void SetVolume(float val)
    {
        backgroundVolumen = val;
    }

    private void SetSounds(float val)
    {
        backgroundSonidos = val;
    }
}
