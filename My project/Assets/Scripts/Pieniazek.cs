using UnityEngine;

public class Coin : MonoBehaviour
{
    public int warto��Punkt�w = 10;
    private bool zebrany = false;

    private void OnTriggerEnter(Collider other)
    {
        if (zebrany) return; 
        if (other.CompareTag("Player"))
        {
            Debug.Log("Kolizja z: " + other.name); 
            zebrany = true;

            FindObjectOfType<MenadzerPunktow>().DodajPunkt(warto��Punkt�w);

            Destroy(gameObject);
        }
    }
}
