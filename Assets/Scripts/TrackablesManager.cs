using UnityEngine;
using Meta.XR.MRUtilityKit;

public class TrackablesManager : MonoBehaviour
{
    [SerializeField] private GameObject redPrefab;
    [SerializeField] private GameObject bluePrefab;
    [SerializeField] private GameObject yellowPrefab;
    [SerializeField] private GameObject blackPrefab;
    [SerializeField] private GameObject greenPrefab;

    private bool redCreated, blueCreated, yellowCreated, blackCreated, greenCreated;

    public void OnTrackableAdded(MRUKTrackable trackable)
    {
        if (trackable.TrackableType != OVRAnchor.TrackableType.QRCode)
            return;

        string qrText = trackable.MarkerPayloadString;

        Debug.Log($"Detected QR code: {qrText}");

        if (qrText == "Red" && !redCreated)
        {
            SpawnRelative(redPrefab, trackable.transform);
            redCreated = true;
            return;
        }

        if (qrText == "Blue" && !blueCreated)
        {
            SpawnRelative(bluePrefab, trackable.transform);
            blueCreated = true;
            return;
        }

        if (qrText == "Yellow" && !yellowCreated)
        {
            SpawnRelative(yellowPrefab, trackable.transform);
            yellowCreated = true;
            return;
        }

        if (qrText == "Black" && !blackCreated)
        {
            SpawnRelative(blackPrefab, trackable.transform);
            blackCreated = true;
            return;
        }

        if (qrText == "Green" && !greenCreated)
        {
            SpawnRelative(greenPrefab, trackable.transform);
            greenCreated = true;
            return;
        }
    }

    private void SpawnRelative(GameObject prefab, Transform qrTransform)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.SetParent(qrTransform, false);

        obj.transform.localPosition = new Vector3(0f, 0f, 0.2f);
        obj.transform.localRotation = Quaternion.Euler(-90f, 180f, 0f); 
    }
}
