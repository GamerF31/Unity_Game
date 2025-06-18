using System.Collections;
using UnityEngine;

public class MazeVisibility : MonoBehaviour
{
    public GameObject mazeObject;  
    public float interval = 4.0f;  

    void Start()
    {
        StartCoroutine(ToggleVisibility());
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            mazeObject.SetActive(!mazeObject.activeSelf);

            yield return new WaitForSeconds(interval);
        }
    }
}
