using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExit : UIBase
{
	static UIExit s_instance;


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
	public void OnBtnClicked_ExitGame()
	{
		Application.Quit();
	}	
	public void OnBtnClicked_Cancel()
	{
		HideUI();
	}
	public void OnBtnClicked_MainMenu()
	{
		Destroy(FindObjectOfType<DontDestroyOnLoad>().gameObject);
		Destroy(FindObjectOfType<ChatManager>().gameObject);
		Gameplay.LoadMenuScene();
	}
}
