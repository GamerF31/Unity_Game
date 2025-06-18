using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class FinishChallenge2 : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public TextMeshProUGUI statsText;
    public AudioSource victorySound;
    public AudioSource backgroundMusic;
    private float startTime;
    private bool levelFinished = false;
    public GameObject fadeOut;
    public GameObject player;
    public Pauza pauseScript;

    private void Start()
    {
        promptText.text = "";
        statsText.text = "";
        startTime = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !levelFinished)
        {
            levelFinished = true;

            if (backgroundMusic != null && backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
            }

            if (victorySound != null)
            {
                victorySound.Play();
            }

            StartCoroutine(ShowFinishStats());

            StartCoroutine(BlockPlayerMovementAfterDelay());
        }
    }

    private IEnumerator ShowFinishStats()
    {
        float elapsedTime = Time.time - startTime;

        promptText.text = "You finished challenge 2";
        yield return new WaitForSeconds(1);

        statsText.text = $"Time: {elapsedTime:F2} seconds";
        yield return new WaitForSeconds(3);

        fadeOut.SetActive(true);

        Invoke("ChangeScene", 4f);
    }

    private IEnumerator BlockPlayerMovementAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        if (player != null)
        {
            var playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
        }

        if (pauseScript != null)
        {
            pauseScript.enabled = false;
        }
    }

    private void ChangeScene()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(16);
    }
}