using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauza : MonoBehaviour
{
    public static bool pausa = false;
    public AudioSource levelMusic;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject welcomePanel;
    public GameObject YouFellPanel;
    public GameObject DeathPanel;
    public static bool IsGamePaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    void Update()
    {
        if (welcomePanel.activeInHierarchy)
        {
            return;
        }
        if (settingsPanel.activeInHierarchy)
        {
            return;
        }
        if (YouFellPanel.activeInHierarchy)
        {
            return;
        }
        if (DeathPanel.activeInHierarchy)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        levelMusic.Pause();
        pausa = true;
        IsGamePaused = true; 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausa = false;
        IsGamePaused = false; 
        levelMusic.UnPause();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
        pausePanel.SetActive(false);
    }
    public void Settings()
    {
        Time.timeScale = 0f;
        levelMusic.Pause();
        pausa = true;
        IsGamePaused = true; 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void SettingsBack()
    {
        Time.timeScale = 0f;
        levelMusic.Pause();
        pausa = true;
        IsGamePaused = true; 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
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
    public void QuitToMenu()
    {
        pausePanel.SetActive(false);
        levelMusic.UnPause();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
        IsGamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0); 
    }

}
