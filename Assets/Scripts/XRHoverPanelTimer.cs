using UnityEngine;
using System.Collections;

public class HandTriggerPanelTimer : MonoBehaviour
{
    [Header("Hover Effect")]
    public Color hoverEmissionColor = Color.white;
    public float hoverIntensity = 0.5f;

    [Header("Panel Settings")]
    public float timeToOpen = 5f;
    public GameObject panelToOpen;

    private Material mat;
    private Color originalEmission;
    private Coroutine timerRoutine;
    private bool handInside = false;

    void Start()
    {
        mat = Instantiate(GetComponent<Renderer>().material);
        GetComponent<Renderer>().material = mat;

        originalEmission = mat.GetColor("_EmissionColor");
        mat.EnableKeyword("_EMISSION");

        if (panelToOpen != null)
            panelToOpen.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.ToLower().Contains("hand"))
        {
            handInside = true;
            mat.SetColor("_EmissionColor", hoverEmissionColor * hoverIntensity);
            timerRoutine = StartCoroutine(HoverTimer());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.ToLower().Contains("hand"))
        {
            handInside = false;

            mat.SetColor("_EmissionColor", originalEmission);

            if (timerRoutine != null)
                StopCoroutine(timerRoutine);
        }
    }

    IEnumerator HoverTimer()
    {
        yield return new WaitForSeconds(timeToOpen);

        if (handInside && panelToOpen != null)
            panelToOpen.SetActive(true);
    }
}

