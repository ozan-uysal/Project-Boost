using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRight : MonoBehaviour
{
    public Movement playerMovement;
    bool isPressed =false;

    void Update()
    {
        if (!isPressed)
            return;
        playerMovement.RotateRight();
    }

    public void PointerDown()
    {
        isPressed = true;
    }
    public void PointerUp()
    {
        isPressed = false; 
    }
    
}
