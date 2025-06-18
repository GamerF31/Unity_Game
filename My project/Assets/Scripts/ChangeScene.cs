using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioSource menuMusic; // Odniesienie do Ÿród³a dŸwiêku muzyki menu

    public void ZmienScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ZmienNaUstawienia()
    {
        SceneManager.LoadScene(1);
    }
    public void zmienCredits()
    {
        SceneManager.LoadScene(3);
    }
    public void Cofnij()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ZmienSceneNaIndeks(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ZmienSceneChalleng(int sceneIndex)
    {
        GameObject menuMusic = GameObject.Find("MenuMusic");
        if (menuMusic != null)
        {
            AudioSource audioSource = menuMusic.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }

        SceneManager.LoadScene(sceneIndex);
    }

}
