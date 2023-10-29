using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public partial class DataManager : MonoBehaviour
{
	static DataManager s_instance;
	GameData m_gameData;

	[SerializeField] bool m_clearDataOnStart;

	string m_dataPath;

	const string KEY__GAMEDATA = "gameData";
	public static GameData GameData => s_instance.m_gameData; 

	#region Unity Methods
	private void Awake()
	{
		s_instance = this;
		DontDestroyOnLoad(this);

		if (m_clearDataOnStart)
		{
			ClearGameData();
		}

		m_gameData = GetGameData();
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion
	void Start()
	{

		//m_playerData = GetPlayerData();
	}

	public static void SaveGameData()
	{
		s_instance.Internal_SaveGameData();
	}
	public static void OnSignUp(LoginData a_loginData)
	{
		s_instance.Internal_OnSignUp(a_loginData);
	}
	public static void OnSignIn()
	{
		s_instance.Internal_OnSignIn();
	}
	void Internal_OnSignIn()
	{
		//get player data from API


		//FOR NOW
		m_gameData = GetGameData();
		if (m_gameData == null)
		{
			Debug.LogError("player data null");
		}
	}
	void Internal_OnSignUp(LoginData a_loginData)
	{
		m_gameData = CreateNewGameData();
		m_gameData.PlayerData.LoginData.CopyFrom(a_loginData);
		Internal_SaveGameData();
	}
	GameData GetGameData()
	{
		if (PlayerPrefs.HasKey(KEY__GAMEDATA))
		{
			string l_data = PlayerPrefs.GetString(KEY__GAMEDATA); Debug.Log(l_data);
			return JsonConvert.DeserializeObject<GameData>(l_data);
		}
		else
		{
			Debug.Log("No Game Data found");
			return null;
		}
	}
	GameData CreateNewGameData()
	{
		GameData l_gameData = new GameData();
		l_gameData.QuestLogData.Add(CreateInitialQuestLogData(0));
		l_gameData.QuestLogData.Add(CreateInitialQuestLogData(1));

		string l_data = JsonConvert.SerializeObject(l_gameData);
		Debug.Log(l_data);
		PlayerPrefs.SetString(KEY__GAMEDATA, l_data);
		return l_gameData;
	}
	QuestLogData CreateInitialQuestLogData(int index) // create quest data
    {
		QuestLogData questLogData = new QuestLogData();
		questLogData.currentQuestIndex = index;
		questLogData.doneSteps = -1;
		return questLogData;
	}
	void ClearGameData()
	{
		PlayerPrefs.DeleteKey(KEY__GAMEDATA);
	}
	void Internal_SaveGameData()
	{
		string l_data = JsonConvert.SerializeObject(m_gameData);
		PlayerPrefs.SetString(KEY__GAMEDATA, l_data);
		Debug.Log("Data Saved");
		Debug.Log(l_data);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}