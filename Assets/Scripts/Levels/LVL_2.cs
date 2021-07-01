using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LVL_2 : GameLevel
{
    [SerializeField] Material GreenMaterial;
    [SerializeField] MeshRenderer buttonMeshRenderer;
    bool lookedAway = false;

    public void HasLookedAway() {
        lookedAway = true;
        buttonMeshRenderer.material = GreenMaterial;
    }

    protected override bool CheckWinCondition() {
        return lookedAway && hit.collider.gameObject.layer == Layers.BUTTON;
    }
}
