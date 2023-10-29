using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISettings : UIBase
{
	static UISettings s_instance;

	[SerializeField] Slider m_sliderMasterVolume;
	float m_curMasterVolume;

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
		s_instance.InitializeUI();
		s_instance.Show();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	void InitializeUI()
	{
		m_sliderMasterVolume.value = DataManager.GameData.SettingsData.MasterVolume;
	}
	public void OnBtnClicked_ClearData()
	{
		PlayerPrefs.DeleteAll();

		Destroy(FindObjectOfType<APIManager>().gameObject);
		Destroy(FindObjectOfType<DataManager>().gameObject);
		Destroy(FindObjectOfType<SoundManager>().gameObject);

		GameManager.LoadScene(EScene.Home);
	}
	public void OnBtnClicked_Close()
	{
		SoundManager.SetMasterVolume(m_curMasterVolume);
		s_instance.Hide();
		UIMainMenu.ShowUI();
	}
	public void OnValChanged_MasterVolume(float a_volume)
	{
		m_curMasterVolume = a_volume;
		SoundManager.OnValChanged_MasterVolume(a_volume);
	}	
}
