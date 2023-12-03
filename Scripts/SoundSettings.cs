using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider;

    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volumeSlider.value;
        }
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        PlayerPrefs.SetFloat("Volume", volume);
    }
}
