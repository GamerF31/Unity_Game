using TMPro; 
using UnityEngine;

public class MenadzerPunktow : MonoBehaviour
{
    public int punkty; 
    public TextMeshProUGUI punktyNaInterfejsie; 

    private void Start()
    {
        AktualizujInterfejs(); 
    }

    public void DodajPunkt(int ilePunkt�w)
    {
        punkty += ilePunkt�w; 
        AktualizujInterfejs(); 
    }

    private void AktualizujInterfejs()
    {
        punktyNaInterfejsie.text = "Points: " + punkty.ToString(); 
    }
}
