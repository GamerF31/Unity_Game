using UnityEngine;
using TMPro;

public class PressKToViewBoard : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public Camera mainCamera;
    public Camera boardCamera;
    public MonoBehaviour playerController;

    private bool isPlayerInTrigger = false;
    private bool isViewingBoard = false;

    private void Start()
    {
        promptText.gameObject.SetActive(false);
        mainCamera.enabled = true;
        boardCamera.enabled = false;

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayerInTrigger)
        {
            isPlayerInTrigger = true;

            if (!Pauza.IsGamePaused) 
            {
                promptText.text = "Press 'K' to view the board";
                promptText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isPlayerInTrigger)
        {
            isPlayerInTrigger = false;
            promptText.gameObject.SetActive(false);

            if (isViewingBoard)
            {
                ToggleCameras();
            }
        }
    }

    private void Update()
    {
        if (Pauza.IsGamePaused)
        {
            promptText.gameObject.SetActive(false);
            return;
        }

        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.K))
        {
            ToggleCameras();
        }
    }

    private void ToggleCameras()
    {
        isViewingBoard = !isViewingBoard;

        mainCamera.enabled = !isViewingBoard;
        boardCamera.enabled = isViewingBoard;

        if (playerController != null)
        {
            playerController.enabled = !isViewingBoard;
        }

        promptText.gameObject.SetActive(!isViewingBoard && !Pauza.IsGamePaused);
    }
}
