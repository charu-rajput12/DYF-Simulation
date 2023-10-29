using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICallSheduled : UIBase
{
	static UICallSheduled s_instance;
	Action m_OnClose;

	[SerializeField] string m_zoomMeetingLink;

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

	public static void ShowUI(Action a_OnClose = null)
	{
		if (GameManager.CurrentScene == EScene.Gameplay)
			UIGameplay.HideUI();

		s_instance.m_OnClose = a_OnClose;
		s_instance.Show();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	public void OnBtnClicked_Close()
	{
		s_instance.Hide();
		m_OnClose?.Invoke();
	}
	public void OnBtnClicked_JoinMeeting()
	{
		Application.OpenURL(m_zoomMeetingLink);
	}
}
