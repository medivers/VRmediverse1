using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPointer : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxDistancePointer = 4.5f;
    [Range(0,1)]
    [SerializeField] private float disPointerObject = 0.95f;
    
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    private readonly string interactableTag = "Interactable";
    private float scalesize = 0.025f;

    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }
    private void GazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
    }
    public void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            
            if (_gazedAtObject != hit.transform.gameObject)
            {
                
                _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnterXR", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection();
            }

            if (hit.transform.CompareTag(interactableTag))
            {
                PointerOnGaze(hit.point);
            }
            else
            {
                PointerOutGaze();
            }
        }
        else
        {
            
            _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }

        
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void PointerOnGaze(Vector3 hitpoint)
    {
        float scaleFactor = scalesize * Vector3.Distance(transform.position, hitpoint);
        pointer.transform.localScale = Vector3.one * scaleFactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position, hitpoint, disPointerObject);
    }
    private void PointerOutGaze()
    {
        pointer.transform.localScale = Vector3.one * 0.1f;
        pointer.transform.parent.transform.localPosition = new Vector3(0, 0, maxDistancePointer);
        pointer.transform.parent.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection(); 

    }
    private Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t*(p1.x - p0.x);
        float y = p0.x + t*(p1.x - p0.x);
        float z = p0.x + t*(p1.x - p0.x);

        return new Vector3(x, y, z);
    }
}