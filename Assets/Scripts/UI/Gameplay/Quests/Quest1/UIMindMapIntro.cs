using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMindMapIntro : UIBase
{
	static UIMindMapIntro s_instance;
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
		s_instance.Hide();
		UIHowToCreateMM.ShowUI();
	}
}


/*
 
additions :

-intract button visible when player gets close to npc
-player can click ui interact button or press 'E' to talk to npc 
-color scheme changed for testing

::ui and characters screen will be in next update


 */