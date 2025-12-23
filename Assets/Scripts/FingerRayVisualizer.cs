using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class FingerRayVisualizer : MonoBehaviour
{
    public float length = 0.05f;
    private LineRenderer lr;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + transform.forward * length);
    }
}