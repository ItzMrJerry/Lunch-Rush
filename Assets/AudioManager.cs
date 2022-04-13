using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject audioObject;

    private AudioSource aud;
    public Slider MusicSlider;
    private float MusicVolume;

    public Slider GameAudioSlider;
    public float GameAudioVolume;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        MusicVolume = PlayerPrefs.GetFloat("Music");
        GameAudioVolume = PlayerPrefs.GetFloat("Game");
        if (MusicSlider != null)
        {
            MusicSlider.value = MusicVolume;
        }
        if (GameAudioSlider != null)
        {
            GameAudioSlider.value = GameAudioVolume;
        }


        aud.volume = MusicVolume;
    }
    private void Update()
    {
        aud.volume = MusicVolume;
        PlayerPrefs.SetFloat("Music", MusicVolume);
        PlayerPrefs.SetFloat("Game", GameAudioVolume);
    }

    public void volumeUpdater1()
    {
        MusicVolume = MusicSlider.value;
    }
    public void volumeUpdater2()
    {
        GameAudioVolume = GameAudioSlider.value;

    }
    public void PlaySound(AudioClip clip)
    {

        GameObject audio = Instantiate(audioObject, transform.position, Quaternion.identity, transform);
        audio.GetComponent<AudioSource>().clip = clip;
    }
}
