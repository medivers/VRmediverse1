using UnityEngine;

public class blood : MonoBehaviour
{
    public AudioSource audioSource;   // Asigna el AudioSource desde el Inspector
    private bool isGazedAt = false;   // Detecta si el usuario está mirando
    private bool hasPlayed = false;   // Evita que se repita

    // Llamado cuando el GazeManager apunta a este objeto
    public void OnPointerEnterXR()
    {
        isGazedAt = true;
        PlayAudioOnce();
    }

    // Llamado cuando el GazeManager deja de apuntar al objeto
    public void OnPointerExitXR()
    {
        isGazedAt = false;
    }

    private void PlayAudioOnce()
    {
        if (isGazedAt && !hasPlayed && audioSource != null)
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }
}
