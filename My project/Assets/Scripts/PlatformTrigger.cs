using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private Animator animator; 
    private bool isActivated = false; 

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            Debug.Log("Gracz dotkn¹³ platformy. Aktywowanie animacji.");
            animator.enabled = true; 
        }
    }
}



