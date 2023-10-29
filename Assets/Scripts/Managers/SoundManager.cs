using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	static SoundManager s_instance;


	#region Unity Methods
	void Awake()
	{
		s_instance = this;
		DontDestroyOnLoad(this);
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion
	void Start()
	{
		SetInitialMasterVolume();
	}

	#region Static Methods
	/// <summary>
	/// Takes values between [0,1]
	/// </summary>
	/// <param name=""></param>
	public static void SetMasterVolume(float a_volume)
	{
		s_instance.Internal_SetMasterVolume(a_volume);
	}
	public static void OnValChanged_MasterVolume(float a_volume)
	{
		s_instance.Internal_OnValChanged_MasterVolume(a_volume);
	}
	public static void SetInitialMasterVolume()
	{
		s_instance.Internal_SetInitialMasterVolume();
	}

	#endregion

	//should be called on btn CloseSettings
	void Internal_SetMasterVolume(float a_volume)
	{
		DataManager.GameData.SettingsData.MasterVolume = a_volume;
		DataManager.SaveGameData();
	}
	void Internal_OnValChanged_MasterVolume(float a_volume)
	{
		//changevolume of audio sources
		SetAllAudiosVolume(a_volume);
	}
	void Internal_SetInitialMasterVolume()
	{
		SetAllAudiosVolume(DataManager.GameData.SettingsData.MasterVolume);
	}
	void SetAllAudiosVolume(float a_volume)
	{
		AudioSource[] l_lstAudioSources = FindObjectsOfType<AudioSource>();
		//Debug.Log($"total {l_lstAudioSources.Length} audios");
		foreach (AudioSource l_audioSource in l_lstAudioSources)
		{
			l_audioSource.volume = a_volume;
		}
	}
}
