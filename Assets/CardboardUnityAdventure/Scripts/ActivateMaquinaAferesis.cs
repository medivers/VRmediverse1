using UnityEngine;
using UnityEngine.Video;

public class ActivateMaquinaAferesis : MonoBehaviour
{
    [Header("Asignar desde el Inspector")]
    public GameObject screen;          // Objeto con el video (RawImage, mesh, etc.)
    public VideoPlayer videoPlayer;    // Componente VideoPlayer del screen

    private bool hasStarted = false;   // Evita reiniciar el video si ya se activó

    void Start()
    {
        if (screen != null)
            screen.SetActive(false); // Oculta la pantalla al iniciar

        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoFinished; // Detecta cuando termina el video
    }

    // Llamado por el GazeManager cuando se mira el objeto
    public void OnPointerEnterXR()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            if (screen != null)
                screen.SetActive(true);

            if (videoPlayer != null)
                videoPlayer.Play();
        }
    }

    // Si se deja de mirar, no pasa nada (el video sigue)
    public void OnPointerExitXR()
    {
        // intencionalmente vacío
    }

    // Cuando el video termina
    private void OnVideoFinished(VideoPlayer vp)
    {
        if (screen != null)
            screen.SetActive(false);

        hasStarted = false; // Permite volver a activarlo si el usuario vuelve a mirar
    }
}
