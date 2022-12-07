
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float delayForRestart = 1f;
    public float delayForNextLevel = 1f;

    public AudioClip crashSound;
    public AudioClip finishSound;

    Movement movementSc;
    AudioSource audioSource;    

    bool isTransitioning=false;
   
    private void Start()
    {
            movementSc= GetComponent<Movement>();
            audioSource= GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "finish":
                    PlayFinishSound();
                StartSuccesSequence();
                break;
            case "Fuel":
            case "obstacle":
                    PlayCrushSound();
                StartCrashSequence();
                break;
            default:
              
                break;
        }

    }
    void StartCrashSequence()
    {
        isTransitioning= true;
       // audioSource.Stop();
        movementSc.enabled = false;
        Invoke("ReloadLevel", delayForRestart);
    }
    void StartSuccesSequence()
    {
        isTransitioning= true;
        //audioSource.Stop();
        movementSc.enabled = false;
        Invoke("OpenNextLevel", delayForNextLevel);
    }
    public void OpenNextLevel()
    {
        int currentSceneIndex =SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex +1;
                  
        if (nextSceneIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
       
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void ReloadLevel()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void PlayCrushSound()
    {
        
            audioSource.PlayOneShot(crashSound);
        
    }
       
    void PlayFinishSound()
    {
        
        
        audioSource.PlayOneShot(finishSound);
    }
}
