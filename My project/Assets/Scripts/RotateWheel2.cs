using UnityEngine;

public class RotateWheel2 : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }
}
