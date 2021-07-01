using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    LevelObjectiveText objectiveText;
    AudioSource audioSource;

    [SerializeField] const int START_LEVEL = 0;
    [SerializeField] GameObject pillarPoisitionReference;
    [SerializeField] GameLevel[] levels;

    int currentLvlIndex;

    GameLevel currentLevel {
        get { return levels[currentLvlIndex]; }
    }

    private void Awake() {
        objectiveText = FindObjectOfType<LevelObjectiveText>();
        audioSource = FindObjectOfType<AudioSource>();

        foreach (GameLevel level in levels) {
            level.gameObject.SetActive(false);
        }
    }

    private void Start() {
        currentLvlIndex = START_LEVEL;
        LoadCurrentLevel();
    }

    public void LoadNextLevel() {
        CloseCurrentLevel();
        audioSource.Play();
        ReadyNextLevel();
    } 

    public void ResetGame() {
        SceneManager.LoadScene(0);
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
