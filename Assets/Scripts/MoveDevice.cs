using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MoveDevice : MonoBehaviour
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
    //public Image tutorial;
    //override protected void OnTrackingFound()
    //{
    //    base.OnTrackingFound();
    //    GetComponent<GetVuMarkInfo>().ShowVuMarkInfo();
    //    tutorial.enabled = false;
    //}
    //protected override void OnTrackingLost()
    //{
    //    base.OnTrackingLost();
    //    tutorial.enabled = true;
    //}
}
