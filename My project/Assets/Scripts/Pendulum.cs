using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float speed = 1.5f; 
    public float limit = 75f; 
    public bool randomStart = false; 
    private float random = 0;

    void Awake()
    {
        if (randomStart)
            random = Random.Range(0f, Mathf.PI * 2); 
    }

    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time * speed + random);
        transform.localRotation = Quaternion.Euler(angle, 0, 0); 
    }
}
