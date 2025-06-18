using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
    public GameObject startPanel;           
    public TextMeshProUGUI countdownText;   
    public AudioSource backgroundMusic;     

    public static bool hasCountdownBeenShown = false;

    void Start()
    {
        if (hasCountdownBeenShown)
        {
            startPanel.SetActive(false);
            countdownText.text = "";
            Time.timeScale = 1f;

            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }
        }
        else
        {
            Time.timeScale = 0f;
            countdownText.text = "";
            StartCountdown();
        }
    }

    public void StartCountdown()
    {
        startPanel.SetActive(false);

        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }

        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        countdownText.text = "";
        Time.timeScale = 1f;

        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }

        hasCountdownBeenShown = true;
    }
}
