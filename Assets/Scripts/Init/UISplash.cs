using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISplash : UIBase
{
	static UISplash s_instance;

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
}
