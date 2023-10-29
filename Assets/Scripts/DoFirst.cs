using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoFirst : UIBase
{
	static DoFirst s_instance;

	[SerializeField] TextMeshProUGUI m_text;


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

	public static void ShowUI(int quest)
	{
		s_instance.ShowINTERNAL(quest);
	}
	void ShowINTERNAL(int quest)
	{
		

		string s = string.Empty;
		if (quest == 1)
			s = "Please complete 'Quest 1' first";
		else if (quest == 2)
		{	s = "Please complete 'Quest 1' as well as 'Quest 2' first";
		}
		else if(quest == 3)
			s = "Please complete 'Quest 1' , 'Quest 2' as well as 'Quest 3' first";


		m_text.text = s;
		Show();
	}
	public void OnBtnClicked_Close()
	{
		Hide();
	}

}
