using UnityEngine;

public class LvlManager : MonoBehaviour
{
    LevelObjectiveText objectiveText;

    [SerializeField] const int START_LEVEL = 0;
    [SerializeField] GameObject pillarPoisitionReference;
    [SerializeField] GameLevel[] levels;

    int currentLvlIndex;

    GameLevel currentLevel {
        get { return levels[currentLvlIndex]; }
    }

    private void Awake() {
        objectiveText = FindObjectOfType<LevelObjectiveText>();

        foreach (GameLevel level in levels) {
            level.gameObject.SetActive(false);
        }

        currentLvlIndex = START_LEVEL;
        LoadCurrentLevel();
    }

    public void LoadNextLevel() {
        CloseCurrentLevel();
        ReadyNextLevel();
    } 

    private void CloseCurrentLevel() {
        currentLevel.gameObject.SetActive(false);
    }

    private void ReadyNextLevel() {
        currentLvlIndex++;
        LoadCurrentLevel();
    }

    private void LoadCurrentLevel() {
        currentLevel.gameObject.SetActive(true);
        objectiveText.UpdateText(currentLevel.objective);

        if (currentLevel.pillar != null) {
            currentLevel.pillar.transform.position =
                pillarPoisitionReference.transform.position;
        }
    }
}
