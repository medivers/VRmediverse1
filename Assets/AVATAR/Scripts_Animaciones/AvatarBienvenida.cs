using UnityEngine;

public class BienvenidaAudio : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    private bool isGazedAt = false;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.Stop();
        }

        if (animator != null)
            animator.speed = 0f;
    }

    public void OnPointerEnterXR()
    {
        Debug.Log("Mirando al avatar...");

        isGazedAt = true;

        if (animator != null)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Bienvenida"))
                animator.Play("Bienvenida");
            animator.speed = 1f;
        }

        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
            else
                audioSource.UnPause();
        }
    }

    public void OnPointerExitXR()
    {
        Debug.Log("Dejé de mirar al avatar...");

        isGazedAt = false;

        if (animator != null)
            animator.speed = 0f;

        if (audioSource != null && audioSource.isPlaying)
            audioSource.Pause();
    }
}
