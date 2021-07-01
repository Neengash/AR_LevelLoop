using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class GameLevel : MonoBehaviour
{
    [SerializeField] ScriptableLevel levelConfig;
    [SerializeField] GameObject _pillar;

    protected LvlManager lvlManager;
    protected RaycastHit hit;
    const int RAY_DISTANCE = 5;

    private void Awake() {
        lvlManager = FindObjectOfType<LvlManager>();
    }

    public GameObject pillar { get {return _pillar; } }

    public string objective {
        get { return levelConfig.levelObjectve; }
    }

    protected abstract bool CheckWinCondition();

    protected virtual void Update() {
        if (UserInteraction() && RaycastHit()) { 
            if (CheckWinCondition()) {
                lvlManager.LoadNextLevel();
            }
        }
    }

    protected bool UserInteraction() {
        return
            Input.touchCount > 0 &&
            Input.GetTouch(0).phase == TouchPhase.Began && 
            !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
    }

    protected bool RaycastHit() {
        return Physics.Raycast(
            Camera.main.ScreenPointToRay(Input.GetTouch(0).position),
            out hit,
            RAY_DISTANCE
        );
    }
}
