using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager s_instance;

    public event Action<int> invokeNextStep;
    public Transform afterLibraryPosition, afterSphinxScroll;

    public Camera mainCamera; 
    [SerializeField] Cainos.PixelArtTopDown_Basic.TopDownCharacterController m_playerController;

    private void Start()
    {
        s_instance = this;

        if (Globals.afterLibrary)
        {
            transform.position = afterLibraryPosition.position;
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y+.62f, transform.position.z);
        }
        else if (Globals.afterSphinxScroll)
        {
            transform.position = afterSphinxScroll.position;
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y + .62f, transform.position.z);
            DialogueManager_Quest2GamePlay.instance.StartQuest(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter : " + collision.collider.name);

        switch (collision.collider.name)
        {
            case "Library Door":
                QuestLogManager.instance.SetStatus(1, 0);
                GameManager.LoadScene(EScene.Library_Maze);
                break;

            case "librarian":
                LibraryManager.instance.DisableColliders(0);
                invokeNextStep.Invoke(0);
                break;

            case "librarian 2":
                LibraryManager.instance.DisableColliders(1);
                invokeNextStep.Invoke(1);
                break;

            case "hint shelf":
                LibraryManager.instance.DisableColliders(2);
                LibraryManager.instance.DisableColliders(3);
                invokeNextStep.Invoke(2);
                break;

            case "ancient scroll box":
                LibraryManager.instance.DisableColliders(4);
                invokeNextStep.Invoke(3);
                break;

            case "end library":
                invokeNextStep.Invoke(4);
                break;
            case "SphinxDoor":
                DialogueManager_Quest2GamePlay.instance.StartQuest(0);
                break;
        }


    }

    public static bool CanPlayerMove
    {
        get => s_instance.m_playerController.CanMove;
        set => s_instance.m_playerController.CanMove = value;
    }
}
