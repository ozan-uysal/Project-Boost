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

    public GameObject player;

    Rigidbody rb;
    public AudioSource audioSource;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        audioSource=player.GetComponent<AudioSource>();
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

    public void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
       
        if (!audioSource.isPlaying)
        {
         audioSource.PlayOneShot(mainEngine);
           
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();

        }
    }

    public void RotatingProcess()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            rightThrusterParticles.Stop();
        }     
        if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            leftThrusterParticles.Stop();   
        }
    }
    public void RotateLeft()
    {
        ApplyRotation(rotatePower);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    public void RotateRight()
    {
        ApplyRotation(-rotatePower);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation=true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false;
    }
}
