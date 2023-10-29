using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICommunicationWithMentor : UIBase
{
	static UICommunicationWithMentor s_instance;
	[SerializeField] GameObject m_goDoneBtn;
	[SerializeField] GameObject m_goCloseBtn;

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

	public static void ShowUI()
	{
		s_instance.OnShow();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}

	void OnShow()
	{
		m_goDoneBtn.SetActive(GameManager.CurrentScene == EScene.Gameplay);
		m_goCloseBtn.SetActive(GameManager.CurrentScene == EScene.MainMenu);

		Show();
	}
	public void OnBtnClicked_Done()
	{
		s_instance.Hide();
		QuestManager.EndQuest(1);
	}
	public void OnBtnClicked_Close()
	{
		Hide();
		if (GameManager.CurrentScene == EScene.MainMenu)
			UIMainMenu.ShowUI();
	}

	public void OnBtnClicked_StartChat()
	{
		Hide();
		ChatManager.Connect();
		UIChat.ShowUI(OnCloseUIChat);
	}
	public void OnBtnClicked_SheduleCall()
	{
		UICallSheduled.ShowUI(OnCloseSheduledCall);
	}
	void OnCloseUIChat()
	{
		ShowUI();
	}
	void OnCloseSheduledCall()
	{
		ShowUI();
	}
}
