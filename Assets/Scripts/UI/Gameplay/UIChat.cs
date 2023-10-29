using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChat : UIBase
{
	static UIChat s_instance;
	[SerializeField] InputField m_ifMessage;
	[SerializeField] Text m_txtChat;

	Action m_OnClose;

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
		ChatManager.OnGetChannelData = s_instance.OnGetChannelData;
		s_instance.Show();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	public void OnBtnClicked_Close()
	{
		ChatManager.Disconnect();
		s_instance.Hide();
		m_OnClose?.Invoke();
	}
	public void OnBtnClicked_Send()
	{
		ChatManager.SendChatMessage(m_ifMessage.text);
		m_ifMessage.text = string.Empty;
	}
	void OnGetChannelData(string a_channelData)
	{
		m_txtChat.text = a_channelData;
	}
}