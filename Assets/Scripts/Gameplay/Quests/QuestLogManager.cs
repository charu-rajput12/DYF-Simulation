using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogManager : MonoBehaviour
{
	public static QuestLogManager instance;

    // Start is called before the first frame update
    void Start()
    {
		instance = this;

    }
    public void SetStatus(int questDoneSteps, int questLogShowIndex)
    {
		Debug.Log("done steps "+ questDoneSteps);
		QuestLogData previousLogData = GetQuestLogData(questLogShowIndex);
		if (previousLogData != null)
        {
            Debug.Log("IXD " + previousLogData.doneSteps);

            if (previousLogData.doneSteps >= questDoneSteps)
                return;
        }
        DataManager.GameData.QuestLogData[questLogShowIndex].doneSteps = questDoneSteps;
        DataManager.SaveGameData();
    }


    public QuestLogData GetQuestLogData(int currentQuestIndex)
	{
		return DataManager.GameData.QuestLogData[currentQuestIndex];

	}
}


