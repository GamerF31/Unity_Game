using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 50f; 

    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self);
    }
}
