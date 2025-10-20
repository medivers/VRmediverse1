using UnityEngine;

public class BienvenidaAudio : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;

    void Start()
    {
        // Reproduce la animación
        animator.Play("Bienvenida");
        // Reproduce el audio
        audioSource.Play();
    }
}
