using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI czasNaEkranie;
    private int aktualnyCzas;

    private void Start()
    {
        aktualnyCzas = 0; 
        StartCoroutine(OdliczanieCzasu());
    }

    private IEnumerator OdliczanieCzasu()
    {
        while (true) 
        {
            czasNaEkranie.text = "Time: " + aktualnyCzas.ToString();
            yield return new WaitForSeconds(1f);
            aktualnyCzas++; 
        }
    }
}
