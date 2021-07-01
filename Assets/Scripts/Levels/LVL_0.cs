using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class LVL_0 : GameLevel
{
    [SerializeField] ARPlaneManager planeManager;
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] GameObject pillarPosition;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    protected override void Update() {
        UpdateTrackerPosition();
        CheckTrackerPlacement();
    }

    private void UpdateTrackerPosition() {
        if (raycastManager.Raycast(new Vector2(Screen.width/2, Screen.height/2), m_Hits, TrackableType.PlaneWithinPolygon)) {
            pillar.SetActive(true);
            pillar.transform.position = m_Hits[0].pose.position;
        } else {
            pillar.SetActive(false);
        }
    }
    
    private void CheckTrackerPlacement() {
        if(pillar.activeInHierarchy && UserInteraction()) {
            planeManager.SetTrackablesActive(false);
            planeManager.enabled = false;
            raycastManager.enabled = false;
            pillarPosition.transform.position =
                pillar.transform.position;
            lvlManager.LoadNextLevel();
        }
    }

	protected override bool CheckWinCondition()
	{
		throw new System.NotImplementedException();
	}
}
