using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mainThrust=100f;
    public float rotatePower=1f;
    public AudioClip mainEngine;
  
    Rigidbody rb;
    AudioSource audioSource;
    
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();
    }

    void Update()
    {
       ThrustProcess();
       RotatingProcess();
    }
    void ThrustProcess()
    {
       if(Input.GetKey(KeyCode.Space))
       {
        rb.AddRelativeForce(0f,1f,0f *mainThrust*Time.deltaTime);
       
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            } 
       }
       else
       {
        audioSource.Stop();
       }
     
    }
     void RotatingProcess()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotatePower);
        }
        else if(Input.GetKey(KeyCode.D))
        {
             ApplyRotation(-rotatePower);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation=true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false;
    
    }
}
