using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
	static Init s_instance;

	void Awake()
	{
		s_instance = this;
       int checker= PlayerPrefs.GetInt("firstTime");
		Debug.Log("checker : " + checker);
		if(checker == 0)
        {

			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("firstTime", 1);
			PlayerPrefs.Save();
		}

	}
	void OnDestroy()
	{
		s_instance = null;
	}
	void Start()
	{
		LoadHomeScene();
	}
	public static void LoadHomeScene()
	{
		GameManager.LoadScene(EScene.Home);
	}
}
