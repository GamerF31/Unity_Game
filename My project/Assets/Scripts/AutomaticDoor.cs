using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public float maximumOpening = 2f;  
    public float maximumClosing = 0f;   
    public float movementSpeed = 5f;     
    public GameObject movingDoor;        
    private bool playerIsHere;           

    void Start()
    {
        playerIsHere = false;
    }

    void Update()
    {
        if (playerIsHere)
        {
            if (movingDoor.transform.localPosition.z < maximumOpening)
            {
                movingDoor.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (movingDoor.transform.localPosition.z > maximumClosing)
            {
                movingDoor.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerIsHere = true;  
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerIsHere = false; 
        }
    }
}