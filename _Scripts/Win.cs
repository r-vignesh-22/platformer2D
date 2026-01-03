using UnityEngine;

public class Win : MonoBehaviour
{
    LevelLoader levelLoader;
    void Awake()
    {
        levelLoader = FindFirstObjectByType<LevelLoader>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            LevelProgress.UnlockNextLevel(levelLoader.CurrentLevel());
            levelLoader.LoadNextLevel();
            
        }
    }
}
