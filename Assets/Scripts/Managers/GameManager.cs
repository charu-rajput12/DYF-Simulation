using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	static GameManager s_instance;
	EScene m_curScene;
	
	public static EScene CurrentScene 
	{
		get => s_instance.m_curScene;
		set => s_instance.m_curScene = value;
	}

	#region Unity Methods

	private void Awake()
	{
		s_instance = this;
		DontDestroyOnLoad(this);
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion

	public static void LoadScene(EScene a_scene)
	{
		s_instance.Internal_LoadScene(a_scene);
	}
	void Internal_LoadScene(EScene a_scene)
	{
		switch (a_scene)
		{
			case EScene.Init:
				SceneManager.LoadScene("Init");
				break;
			case EScene.Home:
				SceneManager.LoadScene("Home");
				break;
			case EScene.MainMenu:
				SceneManager.LoadScene("Menu");
				break;
			case EScene.Gameplay:
				StartCoroutine(LoadInDelay("Gameplay"));
				//SceneManager.LoadScene("Gameplay");
				break;
			case EScene.MiniGames_Wordle:
				SceneManager.LoadScene("MiniGames_Wordle");
				break;
			case EScene.MiniGames_MathBall:
				SceneManager.LoadScene("game_1");
				break;
			case EScene.Library_Maze:
				StartCoroutine(LoadInDelay("Library_Maze"));

				//SceneManager.LoadScene("Library_Maze");
				break;
			case EScene.Quest2_Sphinx:
				//SceneManager.LoadScene("Quest2_Sphinx");
				StartCoroutine(LoadInDelay("Quest2_Sphinx"));

				break;
			default:
				break;
		}
	}
	IEnumerator LoadInDelay(string eScene)
	{
		FadeInOut.instance.FadeInNOut();
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(eScene);
	}
}
