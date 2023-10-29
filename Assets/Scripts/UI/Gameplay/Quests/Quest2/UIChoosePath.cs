using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChoosePath : UIBase
{
	static UIChoosePath s_instance;
	[SerializeField] ToggleGroup m_tglGrpLifePath;

	private void Awake()
	{
		s_instance = this;
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	public static void ShowUI()
	{
		s_instance.Show();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	public void OnBtnClicked_Next()
	{
		ChooseLifePath();

		s_instance.Hide();
		UICommunicationWithMentor.ShowUI();
	}
	public void OnBtnClicked_Close()
	{
		QuestManager.OnCancelQuest();
		s_instance.Hide();
	}
	void ChooseLifePath()
	{
		DataManager.GameData.PlayerData.currentLifePath = ((UIToggle_LifePath)m_tglGrpLifePath.GetFirstActiveToggle()).Lifepath;
		DataManager.SaveGameData();
	}
}