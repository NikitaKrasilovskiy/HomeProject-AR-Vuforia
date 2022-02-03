using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UXController : MonoBehaviour
{
    private ARPlaneManager ARPlaneManager;
    public GameObject handAnim;

    void Start()
    {
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARPlaneManager.planesChanged += ARPlaneManager_planesChanged;
    }

    private void ARPlaneManager_planesChanged(ARPlanesChangedEventArgs obj)
    {
        foreach (var item in obj.added)
        {
            handAnim.SetActive(false);
            break;
        }
    }
}
