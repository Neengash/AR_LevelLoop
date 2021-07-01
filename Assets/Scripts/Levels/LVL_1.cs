using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LVL_1 : GameLevel
{
    protected override bool CheckWinCondition() {
        return hit.collider.gameObject.layer == Layers.BUTTON;
    }
}
