using UnityEngine;

public class StartGame : MonoBehaviour
{
    public CountdownManager countdownManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            countdownManager.StartCountdown();
        }
    }
}
