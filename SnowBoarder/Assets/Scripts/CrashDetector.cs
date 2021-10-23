using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip crashSFX;
    private bool crashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !crashed)
        {
            crashed = true;
            GetComponent<PlayerController>().DisableControls();
            finishEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
