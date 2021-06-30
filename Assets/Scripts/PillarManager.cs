using UnityEngine;

public class PillarManager : MonoBehaviour
{
    [SerializeField] GameObject[] pillars;

    public void SetCurrentPillar(PillarType type) {
        for (int i = 0; i < pillars.Length; i++) {
            pillars[i].SetActive((int)type == i);
        }
    }
}
