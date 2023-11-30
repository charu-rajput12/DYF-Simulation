using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
	static Gameplay s_instance;
	[SerializeField] BoxCollider2D libraryEnterDoor;


	[SerializeField] Cainos.PixelArtTopDown_Basic.TopDownCharacterController m_playerController;

    //public static bool CanPlayerMove
    //{
    //    get => s_instance.m_playerController.CanMove;
    //    set => s_instance.m_playerController.CanMove = value;
    //}
    void Awake()
	{
		s_instance = this;
	}
	void OnDestroy()
	{
		s_instance = null;
	}
	private void Start()
	{
		GameManager.CurrentScene = EScene.Gameplay;
		SoundManager.SetInitialMasterVolume();
		if (Globals.afterLibrary)
			libraryEnterDoor.enabled = false;
	}
	public static void LoadMenuScene()
	{
		GameManager.LoadScene(EScene.MainMenu);
	}



}
