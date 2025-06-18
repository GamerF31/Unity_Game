using UnityEngine;
using UnityEngine.UI;

public class MenuVolumeController : MonoBehaviour
{
    private AudioSource menuMusic; 
    public Slider volumeSlider; 

    private void Start()
    {
        GameObject musicObject = GameObject.Find("MenuMusic");
        if (musicObject != null)
        {
            menuMusic = musicObject.GetComponent<AudioSource>();
        }

        if (menuMusic != null)
        {
            volumeSlider.value = menuMusic.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    private void SetVolume(float value)
    {
        if (menuMusic != null)
        {
            menuMusic.volume = value;
        }
    }
}
