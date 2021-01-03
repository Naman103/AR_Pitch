using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToBegin : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject arsessionorigin;

    private ARRaycastManager _aRRaycastManager;
    private Vector2 touchPos;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _aRRaycastManager = GetComponent<ARRaycastManager>();
    }
    bool TryGetTouchPosition(out Vector2 touchPos)
    {
        if(Input.touchCount>0)
        {
            touchPos = Input.GetTouch(0).position;
            return true;
        }
        touchPos = default;
        return false;
    }
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPos))
            return;
        if(_aRRaycastManager.Raycast(touchPos,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if(objectToPlace.activeInHierarchy==false)
            {
                objectToPlace.transform.position = hitPose.position;
                objectToPlace.transform.localRotation = Camera.main.transform.localRotation;
                objectToPlace.SetActive(true);
                arsessionorigin.GetComponent<ARPlaneManager>().enabled = false;
            }

        }
    }
}
