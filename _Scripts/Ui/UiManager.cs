using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private PlayerInputHandler player;
    private LevelLoader levelLoader;

    [SerializeField] private Text levelText;

    [Header("Level Page UI")]
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject homePanel;

    [Header("Home Page UI")]
    [SerializeField] private GameObject levelSelectPanel;

    private void Awake()
    {
        player = FindFirstObjectByType<PlayerInputHandler>();
        levelLoader = FindFirstObjectByType<LevelLoader>();

        bool isGameScene = levelLoader.CurrentLevel() > 0;

        if (isGameScene)
            ShowGameUI();
        else
            ShowHomeUI();

        UpdateLevelDisplay();
    }

    // ---- UI STATES ----

    private void ShowGameUI()
    {
        levelText.enabled = true;
        homePanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);

        player.enabled = true;
    }

    private void ShowHomeUI()
    {
        homePanel.SetActive(true);
        levelSelectPanel.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(false);

        player.enabled = false;
        levelText.enabled = false;
    }

    private void ShowPauseUI()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        homePanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        player.enabled = false;
    }

    private void ShowLevelSelectUI()
    {
        levelSelectPanel.SetActive(true);

        homePanel.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.SetActive(false);
    }

    private void UpdateLevelDisplay()
    {
        levelText.text = levelLoader.CurrentLevel().ToString();
    }

    // ---- BUTTON EVENTS ----

    public void OnPauseButtonPressed() => ShowPauseUI();
    public void OnResumeButtonPressed() => ShowGameUI();
    public void OnRestartButtonPressed()
    {
        ShowGameUI();
        levelLoader.ReloadCurrentLevel();
    }
    
    public void OnHomeButtonPressed()
    {
        ShowHomeUI();
        levelLoader.LoadHomePage();
    }

    public void OnStartButtonPressed() => ShowLevelSelectUI();
    public void OnLevelButtonPressed() => ShowLevelSelectUI();
    
    public void OnExitButtonPressed()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void OnBackToMenuButtonPressed() => ShowHomeUI();
}
