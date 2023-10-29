using Nature;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISignUp : UIBase
{
	static UISignUp s_instance;

	[SerializeField] TMP_InputField m_ifEmail;
	[SerializeField] TMP_InputField m_ifFirstName;
	[SerializeField] TMP_InputField m_ifLastName;
	[SerializeField] TMP_InputField m_ifPassword;

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

	#region Static Methods
	public static void ShowUI()
	{
		s_instance.Internal_ShowUI();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	} 
	#endregion
	
	void Internal_ShowUI()
	{
		ClearFields();
		s_instance.Show();
	}
	public void OnBtnClicked_SignUp()
	{
		DataManager.OnSignUp(new LoginData
		{
			Email = m_ifEmail.text,
			FirstName = m_ifFirstName.text,
			LastName = m_ifLastName.text,
			Password = m_ifPassword.text
		});
		s_instance.Hide();
		Init.LoadHomeScene();
	}
	public void OnBtnClicked_Login()
	{
		s_instance.Hide();
		UISignIn.ShowUI();
	}
	void ClearFields()
	{
		m_ifEmail.text = string.Empty;
		m_ifFirstName.text = string.Empty; 
		m_ifLastName.text = string.Empty; ;
		m_ifPassword.text = string.Empty; ;
	}
}
