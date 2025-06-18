using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force = 20f; 
    public float stunTime = 1f; 
    private Vector3 hitDir;

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);

            if (collision.gameObject.tag == "Player")
            {
                hitDir = contact.normal;
                PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

                if (playerMovement != null)
                {
                    StartCoroutine(ApplyBounce(playerMovement, -hitDir * force, stunTime));
                }
                else
                {
                    Debug.LogWarning("Obiekt z tagiem 'Player' nie posiada komponentu PlayerMovement.");
                }
                return; 
            }
        }
    }

    private IEnumerator ApplyBounce(PlayerMovement playerMovement, Vector3 pushForce, float duration)
    {
        // Tymczasowe wyłączenie możliwości ruchu
        playerMovement.enabled = false;

        // Dodanie siły odpychania
        CharacterController controller = playerMovement.GetComponent<CharacterController>();
        if (controller != null)
        {
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                // Przesuwanie gracza zgodnie z siłą odpychania
                controller.Move(pushForce * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        // Przywrócenie możliwości ruchu
        playerMovement.enabled = true;
    }
}
