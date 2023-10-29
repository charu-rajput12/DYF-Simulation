using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplay : UIBase
{
	static UIGameplay s_instance;

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
		s_instance.Show();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	public void OnBtnClicked_Options()
	{
		UIExit.ShowUI();
	}
	public void OnBtnClicked_QuestLog()
	{
		QuestLogUI.instance.ShowQuestLog();
	}
	public void OnBtnClicked_Codex()
	{
		Codex_Gameplay.instance.ShowMainScreen();
	}
}
