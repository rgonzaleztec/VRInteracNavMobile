using UnityEngine;

public class CameraPointerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private const float _maxDistance = 35;
    private GameObject _gazedAtObject = null;

    [SerializeField] private GameObject pointer;
    private float scaleSize = 0.025f;
    [Range(0, 1)]
    [SerializeField] float disPointerObject = 0.95f;
    [SerializeField] float maxDistancePointer = 4.5f;
    private readonly string interactableTag = "Interactable";
    private readonly string teleportTag = "Teleporting";




    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {
        if (_gazedAtObject.CompareTag(interactableTag))
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.CompareTag(teleportTag))
            _gazedAtObject?.SendMessage("OnTeleportClick", null, SendMessageOptions.DontRequireReceiver);
    }


    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                if (hit.transform.CompareTag(interactableTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(teleportTag))
                    GazeManager.Instance.StartGazeSelection();
            }
        }
        else
        {
            GazeManager.Instance.CancelGazeSelection();
            _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }


    }
}
