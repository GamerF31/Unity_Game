using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject fadeOut;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ZmienScene1()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 4));
    }

    public void ZmienScene2()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 5));
    }

    public void ZmienScene3()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 6));
    }

    public void ZmienScene4()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 7));
    }

    public void ZmienScene5()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 8));
    }

    public void ZmienScene6()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 9));
    }

    public void ZmienScene7()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 10));
    }

    public void ZmienScene8()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 11));
    }

    public void ZmienScene9()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 12));
    }

    public void ZmienScene10()
    {
        WelcomePanel.hasBeenShown = false;
        StartCoroutine(ZmienSceneCoroutine(14, 13));
    }

    public void Wyjdz()
    {
        SceneManager.LoadScene(15);
    }

    private IEnumerator ZmienSceneCoroutine(int loadingSceneIndex, int targetSceneIndex)
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

        if (fadeOut != null)
        {
            fadeOut.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(loadingSceneIndex);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(targetSceneIndex);
    }


    private IEnumerator LoadSceneWithFade(int sceneIndex)
    {

        if (fadeOut != null)
        {
            fadeOut.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
