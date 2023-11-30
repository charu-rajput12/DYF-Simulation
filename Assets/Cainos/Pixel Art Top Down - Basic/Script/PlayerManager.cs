using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager s_instance;

    public event Action<int> invokeNextStep;
    public Transform afterLibraryPosition;
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter : " + collision.collider.name);
        if(collision.collider.name == "Library Door")
        {
            QuestLogManager.instance.SetStatus(1, 0);
            GameManager.LoadScene(EScene.Library_Maze);
        }
        else if (collision.collider.name == "librarian")
        {
            LibraryManager.instance.DisableColliders(0);
            invokeNextStep.Invoke(0);
        }
        else if (collision.collider.name == "librarian 2")
        {
            LibraryManager.instance.DisableColliders(1);
            invokeNextStep.Invoke(1);

        }
        else if (collision.collider.name == "hint shelf")
        {
            LibraryManager.instance.DisableColliders(2);
            LibraryManager.instance.DisableColliders(3);

            invokeNextStep.Invoke(2);
        }
        else if (collision.collider.name == "ancient scroll box")
        {
            LibraryManager.instance.DisableColliders(4);
            invokeNextStep.Invoke(3);
        }
        else if (collision.collider.name == "end library")
        {
            invokeNextStep.Invoke(4);
        }
    }

    public static bool CanPlayerMove
    {
        get => s_instance.m_playerController.CanMove;
        set => s_instance.m_playerController.CanMove = value;
    }
}
