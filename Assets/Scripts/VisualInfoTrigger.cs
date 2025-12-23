using UnityEngine;

public class VisualInfoTrigger : MonoBehaviour
{
    [Header("UI Fenster")]
    public GameObject infoWindow;

    [Header("Optional: Offset neben dem Objekt")]
    public Vector3 windowOffset = new Vector3(0.1f, 0.1f, 0);

    private void Start()
    {
        if (infoWindow != null)
            infoWindow.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("INFO ÖFFNEN durch: " + other.name);

        if (infoWindow != null)
        {
            infoWindow.SetActive(true);

            infoWindow.transform.position = transform.position + windowOffset;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("INFO SCHLIESSEN durch: " + other.name);

        if (infoWindow != null)
            infoWindow.SetActive(false);
    }
}
