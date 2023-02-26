using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    public Vector3 movementVector;
    public float  movementFactor;
    public float period = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition= transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (period<=Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);
         
        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
        
    }   
}
    
