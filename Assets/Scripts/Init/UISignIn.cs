using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISignIn : UIBase
{
	static UISignIn s_instance;

	[SerializeField] TMP_InputField m_ifEmail;
	[SerializeField] TMP_InputField m_ifPassword;

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
		s_instance.Internal_ShowUI();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	void Internal_ShowUI()
	{
		s_instance.Show();
	}
	public void OnBtnClicked_SignIn()
	{
		if (DataManager.GameData == null)
		{
			Debug.Log("no playerData found");
			return;
		}
		var l_loginData = DataManager.GameData.PlayerData.LoginData;
		if (l_loginData.Email == m_ifEmail.text && l_loginData.Password == m_ifPassword.text)
		{
			//login
			DataManager.OnSignIn();

			s_instance.Hide();
			Init.LoadHomeScene();
		}
		else 
		{
			Debug.Log("incorrect email/pass");
		}
	}
	public void OnBtnClicked_CreateAccount()
	{
		s_instance.Hide();
		UISignUp.ShowUI();
	}
}
