using UnityEngine;

public class GazeAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isGazedAt = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Llamado cuando el objeto es enfocado por el gaze
    public void OnPointerEnterXR()
    {
        isGazedAt = true;
        PlayAudio();
    }

    // Llamado cuando el usuario deja de mirar el objeto
    public void OnPointerExitXR()
    {
        isGazedAt = false;
        StopAudio();
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.time = 0f; // Reinicia el audio desde el inicio
            audioSource.Play();
        }
    }

    private void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Detiene completamente el audio
        }
    }
}

