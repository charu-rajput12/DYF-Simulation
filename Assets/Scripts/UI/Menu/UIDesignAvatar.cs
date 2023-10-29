using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDesignAvatar : UIBase
{
	static UIDesignAvatar s_instance;

	[SerializeField] List<Sprite> m_lstPlayerSprites;
	[SerializeField] Image m_imgPlayer;

	int m_currentSpriteIndex = 0;

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
	public void OnBtnClicked_Close()
	{
		s_instance.Hide();
		UIMainMenu.ShowUI();
	}
	public void OnBtnClicked_Next()
	{
		m_currentSpriteIndex = (m_currentSpriteIndex+1) % m_lstPlayerSprites.Count;
		m_imgPlayer.sprite = m_lstPlayerSprites[m_currentSpriteIndex];
	}
	public void OnBtnClicked_Prev()
	{ 
		m_currentSpriteIndex = (m_currentSpriteIndex-1) % m_lstPlayerSprites.Count;
		m_imgPlayer.sprite = m_lstPlayerSprites[m_currentSpriteIndex];
	}
}
