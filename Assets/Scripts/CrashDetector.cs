using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] float loadDelay = .5f;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
            FindFirstObjectByType<PlayerController>().DisableControls();
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
