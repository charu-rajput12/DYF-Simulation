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
		//FadeInOut.instance.FadeInNOut();

		GameManager.LoadScene(EScene.Gameplay);
		//s_instance.StartCoroutine(s_instance.LoadInDelay());
	}
	//IEnumerator LoadInDelay()
 //   {
	//	FadeInOut.instance.FadeInNOut();
	//	yield return new WaitForSeconds(2);
	//	GameManager.LoadScene(EScene.Gameplay);
	//}
}
