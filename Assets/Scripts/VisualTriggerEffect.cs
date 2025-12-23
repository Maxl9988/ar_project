using UnityEngine;

public class VisualTriggerEffect : MonoBehaviour
{
    private Renderer cubeRenderer;
    public Color highlightColor = Color.red;
    private Color originalColor;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER von: " + other.name);

        cubeRenderer.material.color = highlightColor;
    }

    private void OnTriggerExit(Collider other)
    {
        cubeRenderer.material.color = originalColor;
    }
}


