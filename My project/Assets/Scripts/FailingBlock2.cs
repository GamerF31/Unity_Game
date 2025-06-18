using UnityEngine;
using System.Collections;

public class FallingBlock2 : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gracz dotkn¹³ kostki");

            StartCoroutine(DisableKinematicAfterDelay(0.2f));
        }
    }

    private IEnumerator DisableKinematicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        rb.isKinematic = false; 
    }
}
