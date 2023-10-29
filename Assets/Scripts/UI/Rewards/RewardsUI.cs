using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardsUI : MonoBehaviour
{
    public GameObject allAchievementScreen, achievementPopUp;
    public TMP_Text achievedPopupText;
    public Sprite lockSprite;
    public Sprite unlockSprite;
    public List<Image> statusIcon;
    public RewardsManager rewardsManager;
    public static RewardsUI instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowAchievmentPopup(string achievementText)
    {
        achievedPopupText.text = achievementText;
        achievementPopUp.SetActive(true);
    }

    public void ShowAchievements()
    {
        allAchievementScreen.SetActive(true);
        for (int i = 0; i < statusIcon.Count; i++)
        {
            statusIcon[i].sprite = lockSprite;
        }
        List<int> achivements = DataManager.GameData.PlayerAchievements.achievement_Index;

        if(achivements != null)
        {
            for (int i = 0; i < achivements.Count; i++)
            {
                statusIcon[achivements[i]].sprite = unlockSprite;
            }
        }

    }
    public void SaveAchivement(int achievedIndex)
    {
        DataManager.GameData.PlayerAchievements.achievement_Index.Add(achievedIndex);
        DataManager.SaveGameData();
    }
}
