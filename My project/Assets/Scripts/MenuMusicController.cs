using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicController : MonoBehaviour
{
    private static MenuMusicController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.buildIndex == 4 || scene.buildIndex == 5 || scene.buildIndex == 6) 
        {
            Destroy(gameObject);
        }
    }
}
