using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    static Menu s_instance;

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
		UIMainMenu.ShowUI();
		GameManager.CurrentScene = EScene.MainMenu;
	}
	public static void LoadPlayScene()
    {
		GameManager.LoadScene(EScene.Gameplay);
    }
}
