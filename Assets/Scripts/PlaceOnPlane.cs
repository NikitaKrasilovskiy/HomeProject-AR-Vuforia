using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    ARRaycastManager ARRaycastManager;
    private Vector2 touchPoisition;

    public GameObject Scena;

    static List<ARRaycastHit> Hits = new List<ARRaycastHit>();

    private void Awake()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        Scena.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPoisition = Input.GetTouch(0).position;

            if (ARRaycastManager.Raycast(touchPoisition, Hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = Hits[0].pose;

                Scena.SetActive(true);
                Scena.transform.position = hitPose.position;
                LookAtPlayer(Scena.transform);
            }
        }
    }

    void LookAtPlayer(Transform scene)
    {
        var lookDirection = Camera.main.transform.position - scene.position;
        lookDirection.y = 0;
        scene.rotation = Quaternion.LookRotation(lookDirection);
    }
}