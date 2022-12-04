
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":

            case "finish":

            case "Fuel":



            default:
                break;
        }

    }
}
