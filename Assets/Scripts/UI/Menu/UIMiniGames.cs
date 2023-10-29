using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMiniGames : UIBase
{

	static UIMiniGames s_instance;
	private void Awake()
	{
		s_instance = this;
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	public static void ShowUI()
	{
		s_instance.Show();
	}
	public static void HideUI()
	{
		s_instance.Hide();
	}
	public void OnBtnClicked_HumanCalculator()
	{
		s_instance.Hide();
		UIHumanCalculator.ShowUI();
	}
	public void OnBtnClicked_Close()
	{
		Hide();
		UIMainMenu.ShowUI();
	}
	public void OnBtnClicked_Wordle()
	{
		GameManager.LoadScene(EScene.MiniGames_Wordle);
	}
	public void OnBtnClicked_MathBallGame()
	{
		GameManager.LoadScene(EScene.MiniGames_MathBall);
	}
}
