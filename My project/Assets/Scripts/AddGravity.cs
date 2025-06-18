using UnityEngine;

public class AddGravity : MonoBehaviour
{
    public float extraGravity = -20f; 

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, extraGravity, 0), ForceMode.Acceleration);
    }
}
