using UnityEngine;
using UnityEngine.Video;

public class GazeVideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            Debug.LogError("No se encontró VideoPlayer en el objeto.");
        }
    }

    // Cuando empieza a mirar el objeto
    public void OnPointerEnterXR()
    {
        if (videoPlayer != null && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            Debug.Log("Video reproduciéndose...");
        }
    }

    // Cuando deja de mirar el objeto
    public void OnPointerExitXR()
    {
        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            Debug.Log("Video pausado...");
        }
    }
}
