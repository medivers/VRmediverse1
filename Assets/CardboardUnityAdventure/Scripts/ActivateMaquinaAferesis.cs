using UnityEngine;
using UnityEngine.Video;

public class ActivateMaquinaAferesis : MonoBehaviour
{
    [Header("Referencia al objeto SCREEN con el VideoPlayer")]
    public GameObject screenObject;

    private VideoPlayer videoPlayer;
    private bool videoStarted = false; // bandera para evitar reinicios

    private void Start()
    {
        if (screenObject != null)
        {
            videoPlayer = screenObject.GetComponent<VideoPlayer>();
            screenObject.SetActive(false); // SCREEN inicia oculto
        }
    }

    // Cuando la cámara mira este objeto (la máquina)
    public void OnPointerEnterXR()
    {
        Debug.Log("Mirando la máquina de aféresis → mostrando pantalla");

        // Solo inicia el video una vez
        if (!videoStarted && screenObject != null)
        {
            screenObject.SetActive(true);

            if (videoPlayer != null)
            {
                videoPlayer.Play();
                videoStarted = true; // marca que ya se inició
            }
        }
    }

    // Cuando deja de mirarlo
    public void OnPointerExitXR()
    {
        // Ya no detenemos ni ocultamos el video, para que siga hasta el final
        Debug.Log("Dejó de mirar la máquina, pero el video sigue reproduciéndose.");
    }
}
