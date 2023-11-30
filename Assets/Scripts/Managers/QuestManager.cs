using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	static QuestManager s_instance;

	[SerializeField] List<QuestBase> m_lstQuests;
	[SerializeField] List<StartQuestDialogueData> m_lstStartQuestDialogueData;

	//public static int CurrentQuest { get => s_instance.m_currentQuest; }


	#region Unity Methods
	private void Awake()
	{
		s_instance = this;
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion


	#region Static Methods
	public static void OnAltarTriggerEnter2D(Collider2D a_other)
	{
		//s_instance.Internal_OnAltarTriggerEnter2D();
	}
	public static void OnAltarTriggerExit2D(Collider2D a_other)
	{
		//s_instance.Internal_OnAltarTriggerExit2D();
	}
	public static void EndQuest(int index)
	{
		s_instance.Internal_EndQuest(index);
	}
	public static void OnCancelQuest()
	{
		UIGameplay.ShowUI();
	}
	#endregion

	public static void OnInteract(Npc a_npc, Action a_OnCancel)
	{
		int l_currentQuest = DataManager.GameData.PlayerData.currentQuest;
		int l_npcQuest = a_npc.NpcId;

		if (l_npcQuest <= l_currentQuest)
		{
			if (l_currentQuest > 2) return; //there are 3 quests rn

			//start quest
			s_instance.ShowStartQuestDialogue(l_npcQuest, a_npc.Sprite, a_OnCancel);

		}
		else
		{ 
			//show "complete other quests first dialogue box"
		}

		
	}

	#region Private Methods
	void Internal_OnAltarTriggerEnter2D()
	{
		int l_currentQuest = DataManager.GameData.PlayerData.currentQuest;
		ShowStartQuestDialogue(l_currentQuest,null, null);
	}
	void Internal_OnAltarTriggerExit2D()
	{

	}
	void ShowStartQuestDialogue(int a_currentQuest,Sprite a_spriteNpc, Action a_OnCancel)
	{
		UIStartQuestDialogue.ShowUI(
			m_lstStartQuestDialogueData[a_currentQuest].Heading,
			m_lstStartQuestDialogueData[a_currentQuest].Description,
			a_spriteNpc,
			() => StartQuest(a_currentQuest),
			() => 
			{
				PlayerManager.CanPlayerMove = true;
				a_OnCancel?.Invoke();
			}
			);
	}
	int a_currentRunningQuest;
	void StartQuest(int a_questNumber)
	{
		a_currentRunningQuest = a_questNumber;
		IQuest l_quest = (IQuest)m_lstQuests[a_questNumber];
		l_quest.StartQuest();
	}
	void Internal_EndQuest(int index)
	{
		UIGameplay.ShowUI();
		int l_currentQuest = DataManager.GameData.PlayerData.currentQuest;
		((IQuest)s_instance.m_lstQuests[index]).EndQuest();

		if (index == l_currentQuest) //if its newest quest that player have completed
		{
			l_currentQuest++;
			s_instance.SetCurrentQuest(l_currentQuest);
		}
	}
	void SetCurrentQuest(int a_quest)
	{
		DataManager.GameData.PlayerData.currentQuest= a_quest;
		DataManager.SaveGameData();
	}
	#endregion
}
[Serializable]
public class StartQuestDialogueData
{
	[SerializeField] string m_heading;
	[SerializeField] string m_description;
	public string Heading => m_heading;
	public string Description => m_description;
}