using UnityEngine;

public class Coin : MonoBehaviour
{
    public int wartoœæPunktów = 10;
    private bool zebrany = false;

    private void OnTriggerEnter(Collider other)
    {
        if (zebrany) return; 
        if (other.CompareTag("Player"))
        {
            Debug.Log("Kolizja z: " + other.name); 
            zebrany = true;

            FindObjectOfType<MenadzerPunktow>().DodajPunkt(wartoœæPunktów);

            Destroy(gameObject);
        }
    }
}
