using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_2_PILLAR : MonoBehaviour
{
    [SerializeField] LVL_2 levelRef;
    bool hasBennSeen = false;

    private void OnEnable() {
        hasBennSeen = false;
    }

    private void OnBecameVisible() {
        if (!hasBennSeen) {
            hasBennSeen = true;
        }
    }

    private void OnBecameInvisible() {
        if (hasBennSeen) {
            levelRef.HasLookedAway();
        }
    }
}
