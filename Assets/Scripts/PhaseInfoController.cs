using UnityEngine;

public class PhaseInfoController : MonoBehaviour
{
    [Header("Panel asociado a este objeto")]
    public GameObject infoPanel;

    private void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false); // apagado al inicio
    }

    // Llamado cuando la cámara empieza a mirar este objeto
    public void OnPointerEnterXR()
    {
        GazeManager.Instance.OnGazeSelection += ShowPanel;
        GazeManager.Instance.StartGazeSelection();
    }

    // Llamado cuando la cámara deja de mirar este objeto
    public void OnPointerExitXR()
    {
        GazeManager.Instance.OnGazeSelection -= ShowPanel;
        GazeManager.Instance.CancelGazeSelection();
    }

    // Acción final cuando se completa el gaze (barra llena)
    public void OnPointerClickXR()
    {
        ShowPanel();
    }

    private void ShowPanel()
    {
        // Apaga todos los paneles antes de mostrar el actual
        foreach (var panel in GameObject.FindGameObjectsWithTag("InfoPanel"))
        {
            panel.SetActive(false);
        }

        if (infoPanel != null)
            infoPanel.SetActive(true);

        // después de mostrar, me desuscribo para evitar duplicados
        GazeManager.Instance.OnGazeSelection -= ShowPanel;
    }
}
