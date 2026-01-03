using UnityEngine;

public static class LevelProgress 
{
    public const string UNLOCK_KEY = "UnlockedLevel";
    public static int GetUnlockedLevel()
    {
        return PlayerPrefs.GetInt(UNLOCK_KEY, 1);
    }
    public static void UnlockNextLevel(int currentLevel)
    {
        int nextLevel = currentLevel + 1;
        if (nextLevel > GetUnlockedLevel())
        {
            PlayerPrefs.SetInt(UNLOCK_KEY, nextLevel);
            PlayerPrefs.Save();
        }
    }
}