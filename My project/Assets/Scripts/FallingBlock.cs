using UnityEngine;

public class FallingBlock : MonoBehaviour
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

            rb.isKinematic = false;
        }
    }
}
