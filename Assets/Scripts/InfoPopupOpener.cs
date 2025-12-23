using UnityEngine;

public class InfoPopupOpener : MonoBehaviour
{
    public GameObject infoWindow;
    private bool isOpen = false;

    void Start()
    {
        if (infoWindow != null)
            infoWindow.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {


        if (!isOpen)
        {
            OpenWindow();
        }
    }

    public void OpenWindow()
    {
        if (infoWindow != null)
        {
            infoWindow.SetActive(true);
            isOpen = true;
        }
    }

    public void CloseWindow()
    {
        if (infoWindow != null)
        {
            infoWindow.SetActive(false);
            isOpen = false;
        }
    }
}
