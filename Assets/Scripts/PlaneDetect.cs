using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetect : MonoBehaviour
{
    [SerializeField] ARPlaneManager planeManager;
    [SerializeField] ARRaycastManager raycastManager;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField] GameObject objectTracker;

    void Update() {
        // Get current center position
        // If Colliding with plane, spawn/move cube
        if (raycastManager.Raycast(new Vector2(Screen.width/2, Screen.height/2), m_Hits, TrackableType.PlaneWithinPolygon)) {
            objectTracker.SetActive(true);
            objectTracker.transform.position = m_Hits[0].pose.position;
        } else {
            objectTracker.SetActive(false);
        }
    }
}
