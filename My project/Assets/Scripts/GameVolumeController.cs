using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioSource backgroundMusic;  
    public Slider volumeSlider;          

    void Start()
    {
        if (backgroundMusic != null)
        {
            if (backgroundMusic.volume == 0f) 
            {
                backgroundMusic.volume = 0.3f; 
            }
            backgroundMusic.Play(); 
        }
        

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;
        }
    }
}
