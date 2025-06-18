using UnityEngine;

public class IceSurface : MonoBehaviour
{
    public float iceDrag = 0.05f; 
    public float normalDrag = 1f; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Pasywka");
            if (playerRb != null)
            {
                playerRb.drag = iceDrag;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.drag = iceDrag;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.drag = normalDrag;
            }
        }
    }
}
