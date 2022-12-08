using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mainThrust=100f;
    public float rotatePower=1f;

    public AudioClip mainEngine;

    public ParticleSystem mainEngineParticles;
    public ParticleSystem leftThrusterParticles;
    public ParticleSystem rightThrusterParticles;

    Rigidbody rb;
    AudioSource audioSource;
    
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();
        //mainEngineParticles=GameObject.Find("Rocket Jet Particles").GetComponent<ParticleSystem>();
        //leftThrusterParticles= GameObject.Find("Side Thruster Particles").GetComponent<ParticleSystem>();
        //rightThrusterParticles = GameObject.Find("Side Thruster Particles").GetComponent<ParticleSystem>();
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
            StartThrusting();
        }
        else
       {
        audioSource.Stop();
        mainEngineParticles.Stop();
       }
     
    }

     void StartThrusting()
    {
        rb.AddRelativeForce(0f, 1f, 0f * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    void RotatingProcess()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotatePower);
            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }
        else
        {
            rightThrusterParticles.Stop();
        }     
        if(Input.GetKey(KeyCode.D))
        {
             ApplyRotation(-rotatePower);
            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }
        else
        {
          
            leftThrusterParticles.Stop();   
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation=true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false;
    
    }
}
