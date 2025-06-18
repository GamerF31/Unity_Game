using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DeathZone : MonoBehaviour
{
    public float deathHeight = 50f;
    public GameObject youFell;
    public GameObject panel;
    public static bool pausa = false;
    public AudioSource levelMusic;
    public static bool IsGamePaused = false;
    private bool isRespawning = false;
    public GameObject settingsPanel;

    void Start()
    {
        panel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (transform.position.y < deathHeight && !isRespawning)
        {
            StartCoroutine(DieAndRespawn());
        }
    }

    IEnumerator DieAndRespawn()
    {
        isRespawning = true;
        Debug.Log("Gracz zgin¹³!");
        youFell.SetActive(true);

        yield return new WaitForSeconds(3);

        youFell.SetActive(false);
        Time.timeScale = 0f;
        levelMusic.Pause();
        pausa = true;
        IsGamePaused = true; 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        panel.SetActive(true);
        isRespawning = false;
    }
    public void Restart(int index)
    {
        Time.timeScale = 1f;
        pausa = false;
        IsGamePaused = false; 
        levelMusic.UnPause();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
        SceneManager.LoadScene(index);
    }
    public void Settings()
    {
        Time.timeScale = 0f;
        levelMusic.Pause();
        pausa = true;
        IsGamePaused = true; 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        panel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void QuitToMenu()
    {
        panel.SetActive(false);
        levelMusic.UnPause();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Odblokowanie kursora
        IsGamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0); // Wczytuje scenê o indeksie 1 (menu g³ówne)
    }
}
