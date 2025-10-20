using UnityEngine;

public class blood : MonoBehaviour
{
    public AudioSource audioSource;   // Asigna el AudioSource desde el Inspector
    private bool isGazedAt = false;   // Detecta si el usuario está mirando

    // Llamado cuando el GazeManager apunta a este objeto
    public void OnPointerEnterXR()
    {
        isGazedAt = true;
        PlayAudio();
    }

    // Llamado cuando el GazeManager deja de apuntar al objeto
    public void OnPointerExitXR()
    {
        isGazedAt = false;
        StopAudio();
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.time = 0f; // Reinicia el audio desde el principio
            audioSource.Play();
        }
    }

    private void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
