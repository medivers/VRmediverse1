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
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Llamado cuando el usuario deja de mirar el objeto
    public void OnPointerExitXR()
    {
        isGazedAt = false;
    }
}
