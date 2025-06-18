using UnityEngine;

public class WelcomePanel : MonoBehaviour
{
    public GameObject welcomePanel;
    public AudioSource levelMusic;

    public static bool hasBeenShown = false;

    private bool isPanelActive = false;

    void Start()
    {
        if (hasBeenShown)
        {
            welcomePanel.SetActive(false);
            isPanelActive = false;
            Time.timeScale = 1f;
            levelMusic.UnPause();
        }
        else
        {
            welcomePanel.SetActive(true);
            isPanelActive = true;
            Time.timeScale = 0f;
            levelMusic.Pause();
        }
    }

    void Update()
    {
        if (isPanelActive && Input.GetKeyDown(KeyCode.E))
        {
            welcomePanel.SetActive(false);
            isPanelActive = false;

            Time.timeScale = 1f;
            levelMusic.UnPause();

            hasBeenShown = true;
        }
    }
}
