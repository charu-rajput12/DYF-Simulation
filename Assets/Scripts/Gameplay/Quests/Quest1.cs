using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : QuestBase, IQuest
{
	protected override void Start()
	{
		base.Start();
	}
	#region IQuest IMPL
	public void StartQuest()
	{
		OnStartQuest();
	}
	public void EndQuest()
	{
		OnEndQuest();
	}
	#endregion

	void OnStartQuest()
	{
		UIMindMapIntro.ShowUI();
		QuestLogManager.instance.SetStatus(0, 0);

	}
	void OnEndQuest()
	{
		//Gameplay.CanPlayerMove = true;
		Debug.Log("quest 1 ");
		Quest1Quiz.instance.StartQuiz();
		QuestLogManager.instance.SetStatus(1, 0);
		RewardsUI.instance.SaveAchivement(0); // achieved 0 index task in achievement
		RewardsUI.instance.ShowAchievmentPopup("Completed any quest");
	}

}
