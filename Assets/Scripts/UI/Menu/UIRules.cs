using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRules : UIBase
{
	static UIRules s_instance;

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
	public void OnBtnClicked_Next()
	{
		UIDesignAvatar.ShowUI();
	}
	public void OnBtnClicked_Close()
	{
		Menu.LoadPlayScene();
	}
}
