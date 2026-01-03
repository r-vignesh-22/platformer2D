using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int lastLevelIndex;

    private void Awake()
    {
        lastLevelIndex = SceneManager.sceneCountInBuildSettings - 1;
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel()
    {
        int currentIndex = CurrentLevel();
        int nextIndex = currentIndex + 1;

        if (currentIndex < lastLevelIndex)
            SceneManager.LoadScene(nextIndex);
        else
            LoadHomePage();
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(CurrentLevel());
    }

    public void LoadHomePage()
    {
        SceneManager.LoadScene(0);
    }

    public int CurrentLevel() { return SceneManager.GetActiveScene().buildIndex; }
}
