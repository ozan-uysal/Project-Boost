
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "finish":
                break;
            case "Fuel":
                break;
            default:
                ReloadLevel();
                break;
        }

    }
    public void ReloadLevel()
    {
        int currentScene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
