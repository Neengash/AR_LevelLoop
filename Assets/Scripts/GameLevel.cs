using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameLevel : MonoBehaviour
{
    [SerializeField] ScriptableLevel levelConfig;
    [SerializeField] GameObject _pillar;

    protected LvlManager lvlManager;

    private void Awake() {
        lvlManager = FindObjectOfType<LvlManager>();
    }

    public GameObject pillar { get {return _pillar; } }

    public string objective {
        get { return levelConfig.levelObjectve; }
    }
}
