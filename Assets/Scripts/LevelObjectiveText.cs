using UnityEngine;
using TMPro;

public class LevelObjectiveText : MonoBehaviour
{
    TextMeshProUGUI levelText;

    private void Awake() {
        levelText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string text) {
        levelText.text = text;
    }
}
