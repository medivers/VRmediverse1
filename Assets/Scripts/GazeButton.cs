using UnityEngine;
using UnityEngine.SceneManagement;

public class GazeButton : MonoBehaviour
{
    [Header("Nombre exacto de la escena en Build Profile")]
    public string sceneName;

        public void OnPointerClickXR()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("Cargando escena: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("No asignaste un nombre de escena en: " + gameObject.name);
        }
    }

    // Opcional: feedback visual
    public void OnPointerEnterXR()
    {
        Debug.Log("Mirando al objeto: " + gameObject.name);
        GetComponent<Renderer>().material.color = new Color(0.5f, 0.8f, 1f); ;
    }

    public void OnPointerExitXR()
    {
        Debug.Log("Dejaste de mirar el objeto: " + gameObject.name);
        GetComponent<Renderer>().material.color = Color.white;
    }
}