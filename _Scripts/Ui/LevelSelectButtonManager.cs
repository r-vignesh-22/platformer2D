using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    private void Start()
    {
        int unlockLevel = LevelProgress.GetUnlockedLevel(); 
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelNumber = i + 1;
            levelButtons[i].interactable = levelNumber<=unlockLevel;
        }
    }
}
