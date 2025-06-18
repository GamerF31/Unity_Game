using System.Collections;
using UnityEngine;

public class Level001 : MonoBehaviour
{
    public GameObject fadeIn;

    void Start()
    {
        LevelRedirector.redirectToLevel = 3;
        StartCoroutine(FadeInOff());
    }

    IEnumerator FadeInOff()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
    public static class LevelRedirector
    {
        public static int redirectToLevel;
    }

}
