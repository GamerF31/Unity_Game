using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
