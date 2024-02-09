using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : UIBase
{
	static UIMainMenu s_instance;

	[SerializeField] GameObject m_goCommunicationBtn;
	#region Unity Methods
	void Awake()
	{
		s_instance = this;
	}
	void OnDestroy()
	{
		s_instance = null;
	}
	#endregion

	public static void ShowUI()
	{
		s_instance.OnShowUI();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}

	void OnShowUI()
	{
		int l_curQuest = DataManager.GameData.PlayerData.currentQuest;
		bool l_commBtnState = l_curQuest > 1;
		m_goCommunicationBtn.SetActive(l_commBtnState);
		
		Show();
	}
	public void OnBtnClicked_DesignAvatar()
	{
		s_instance.Hide();
		UIDesignAvatar.ShowUI();
	}
	public void OnBtnClicked_PlayerProfile()
	{
		s_instance.Hide();
		UIPlayerProfile.ShowUI();
	}
	public void OnBtnClicked_Start()
	{
		//s_instance.Hide();
		Menu.LoadPlayScene();
	}
	public void OnBtnClicked_Instructions()
	{
		s_instance.Hide();
		UIInstructions.ShowUI();
	}
	public void OnBtnClicked_Settings()
	{
		s_instance.Hide();
		UISettings.ShowUI();
	}
	public void OnBtnClicked_Quests()
	{
		s_instance.Hide();
		UIQuests.ShowUI();
	}
	public void OnBtnClicked_MiniGames()
	{
		UIMiniGames.ShowUI();
		Hide();
	}
	public void OnBtnClicked_Communication()
	{
		Hide();
		UICommunicationWithMentor.ShowUI();
	}
	public void OnBtnClicked_QuestLog()
	{
		QuestLogUI.instance.ShowQuestLog();
	}
	public void OnBtnClicked_Achievements()
	{
		RewardsUI.instance.ShowAchievements();
	}
}
