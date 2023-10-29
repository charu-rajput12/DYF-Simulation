using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
	static Home s_instance;
	[SerializeField] float m_splashScreenTime = 2f;

	void Awake()
	{
		s_instance = this;
	}
	void OnDestroy()
	{
		s_instance = null;
	}
	void Start()
	{
		GameManager.CurrentScene = EScene.Home;
		Invoke("HideSplashScreen", m_splashScreenTime);
	}
	void HideSplashScreen()
	{
		//try login
		if (DataManager.GameData != null)
		{
			//auto sign in
			LoadMenuScene();
			return;
		}

		UISplash.HideUI();
		UISignIn.ShowUI();
	}
	public static void LoadMenuScene()
	{
		GameManager.LoadScene(EScene.MainMenu);
	}
}
