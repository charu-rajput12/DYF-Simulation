using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogUI : MonoBehaviour
{
    public GameObject allQuest;
    public GameObject[] questLogUI;
    public StatusButtons[] statusButtons_Quest1;
    public StatusButtons[] statusButtons_Quest2;

    public static QuestLogUI instance;

    private void Start()
    {
        instance = this;
    }
    public void ShowQuestLog()
    {
        allQuest.SetActive(true);
    }
    public void ShowQuestLog(int index)
    {
        allQuest.SetActive(false);
        foreach (var item in questLogUI)
        {
            item.SetActive(false);
        }
        questLogUI[index].SetActive(true);
    }
    
    public void ShowQuestDetails(int currentQuestIndex)
    {
        QuestLogData questLogData = QuestLogManager.instance.GetQuestLogData(currentQuestIndex);
        ResetAllButtons();

        if (questLogData == null)
            return;
        Debug.Log(questLogData.currentQuestIndex);
       
        for (int i=0; i<= questLogData.doneSteps; i++)
        {
            if (currentQuestIndex == 0)
                SetStatus(statusButtons_Quest1[i]);
            else if (currentQuestIndex == 1)
                SetStatus(statusButtons_Quest2[i]);
        }
    }
    void SetStatus(StatusButtons statusBtn)
    {
        statusBtn.doneButton.SetActive(true);
        statusBtn.newButton.SetActive(false);
    }
    void ResetAllButtons()
    {
        foreach (var item in statusButtons_Quest1)
        {
            item.doneButton.SetActive(false);
            item.newButton.SetActive(true);
        }
        foreach (var item in statusButtons_Quest2)
        {
            item.doneButton.SetActive(false);
            item.newButton.SetActive(true);
        }

    }
}
[System.Serializable]
public class StatusButtons
{
    public GameObject newButton;
    public GameObject doneButton;
}
