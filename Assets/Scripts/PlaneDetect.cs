using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetect : MonoBehaviour
{
    public ARPlaneManager planeManager;

    public GameObject myCube;

    bool cubeSpawned = false;

    void Start() {
        
    }

    void Update() {
        foreach (ARPlane plane in planeManager.trackables) {
            if(plane.alignment == PlaneAlignment.HorizontalUp) {
                if (!cubeSpawned) {
                    cubeSpawned = true;
                    Instantiate(myCube, plane.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
