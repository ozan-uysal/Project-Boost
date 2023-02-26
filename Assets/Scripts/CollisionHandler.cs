
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class CollisionHandler : MonoBehaviour
{
    public float delayForRestart = 1f;
    public float delayForNextLevel = 1f;

    public AudioClip crashSound;
    public AudioClip finishSound;

    public ParticleSystem finishParticles;
    public ParticleSystem crashParticles;

    Movement movementSc;
    AudioSource audioSource;    

    bool isTransitioning=false;
    bool collisionDisabled=false;
   
    private void Start()
    {
            movementSc= GetComponent<Movement>();
            audioSource= GetComponent<AudioSource>();
            //crashParticles = GameObject.Find("Explosion Particles").GetComponent<ParticleSystem>();
            //finishParticles = GameObject.Find("Success Particles").GetComponent<ParticleSystem>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled)
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
                break;
            default:
                PlayCrushSound();
                StartCrashSequence();
                break;
        }

    }
     void Update()
    {
        RespondToDebugKeys();
    }
    void StartCrashSequence()
    {
        isTransitioning= true;
       // audioSource.Stop();
        movementSc.enabled = false;
        crashParticles.Play();
        Invoke("ReloadLevel", delayForRestart);
    }
    void StartSuccesSequence()
    {
        isTransitioning= true;
        //audioSource.Stop();
        movementSc.enabled = false;
        finishParticles.Play();
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
    void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
           OpenNextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
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
