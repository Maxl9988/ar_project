using UnityEngine;

public class BillboardToCamera : MonoBehaviour
{
    void Update()
    {
        if (Camera.main == null) return;
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
