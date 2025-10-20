using UnityEngine;

public class cresta : MonoBehaviour
{
    [Header("FBX con Animator Controller")]
    public GameObject animatedFBX; // Asigna el FBX desde el inspector
    private Animator animator;

    void Start()
    {
        if (animatedFBX != null)
        {
            animator = animatedFBX.GetComponent<Animator>();
            animatedFBX.SetActive(false); // Ocultar al inicio
        }
        else
        {
            Debug.LogWarning("No se ha asignado el FBX animado en el inspector.");
        }
    }

    // Cuando el usuario comienza a mirar el objeto
    public void OnPointerEnterXR()
    {
        if (animatedFBX != null)
        {
            animatedFBX.SetActive(true); // Mostrar el modelo

            // Reinicia la animación al principio
            if (animator != null)
            {
                animator.Rebind();
                animator.Update(0f);
            }
        }
    }

    // Cuando el usuario deja de mirar el objeto
    public void OnPointerExitXR()
    {
        if (animatedFBX != null)
        {
            animatedFBX.SetActive(false); // Ocultar modelo
        }
    }
}
