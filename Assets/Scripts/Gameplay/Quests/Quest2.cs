using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2 : QuestBase, IQuest
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
		Gameplay.CanPlayerMove = false;
		UIChoosePath.ShowUI();
		QuestLogManager.instance.SetStatus(0, 1);

	}
	void OnEndQuest()
	{
		//Gameplay.CanPlayerMove = true;
		Quest2Quiz.instance.StartQuiz();
	}
}
