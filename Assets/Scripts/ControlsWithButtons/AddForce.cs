using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddForce : MonoBehaviour
{ 

    bool isPressed = false;
    public Movement playerMovement;
    

    private void Start()
    {
        
    }
    public void Update()
    {
        if (!isPressed) 
          return;
          playerMovement.StartThrusting();

        //if (!playerMovement.audioSource.isPlaying)
        //{
        playerMovement.audioSource.PlayOneShot(playerMovement.mainEngine);
        Debug.Log("calýsýyi");
        //}
        //else
        //{
        //    playerMovement.audioSource.Stop();
        //}
        if (!playerMovement.mainEngineParticles.isPlaying)
        {
            playerMovement.mainEngineParticles.Play();
        }
       


    }
    public void PointerDown()
    {
        isPressed= true;
    }
    public void PointerUp()
    {
        isPressed = false;
    }
}
