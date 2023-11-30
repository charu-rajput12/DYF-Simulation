using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStartQuestDialogue : UIBase
{
	static UIStartQuestDialogue s_instance;

	[SerializeField] Image m_imgNpc;
	[SerializeField] TextMeshProUGUI m_txtHeading;
	[SerializeField] TextMeshProUGUI m_txtDescription;
	[SerializeField] Button m_btnStart;
	[SerializeField] Button m_btnCancel;

	Action m_onBtnClickedCancel;
	Action m_onBtnClickedStart;

	private void Awake()
	{
		s_instance = this;
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	public static void ShowUI(string a_heading, string a_desc, Sprite a_spriteNpc, Action a_onBtnClickedStart, Action a_onBtnClickedCancel)
	{
		s_instance.Internal_ShowUI(a_heading, a_desc, a_spriteNpc,a_onBtnClickedStart, a_onBtnClickedCancel);
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	void Internal_ShowUI(string a_heading, string a_desc, Sprite a_spriteNpc, Action a_onBtnClickedStart, Action a_onBtnClickedCancel)
	{

		PlayerManager.CanPlayerMove = false;

		m_imgNpc.sprite = a_spriteNpc;
		m_txtHeading.text = a_heading;
		m_txtDescription.text = a_desc;
		m_onBtnClickedCancel = a_onBtnClickedCancel;
		m_onBtnClickedStart = a_onBtnClickedStart;

		s_instance.Show();
	}
	public void OnBtnClicked_StartQuest()
	{
		m_onBtnClickedStart?.Invoke();
		s_instance.Hide();
	}
	public void OnBtnClicked_Cancel()
	{
		m_onBtnClickedCancel?.Invoke();
		s_instance.Hide();
		QuestManager.OnCancelQuest();
	}
}
