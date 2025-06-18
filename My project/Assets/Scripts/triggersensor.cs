using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    public GameObject cylinderToDestroy; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(cylinderToDestroy); 
            Debug.Log("Cylinder zosta³ zniszczony!");
        }
    }
}
